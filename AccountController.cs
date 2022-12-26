using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Pagen.Models;

namespace Pagen.Controllers
{
    public class AccountController : Controller
    {
        #region Readonly fields

        private readonly ApplicationContext
            _applicationContext = new ApplicationContext();

        #endregion

        #region Properties

        private ApplicationUserManager UserManager => HttpContext.GetOwinContext()
            .GetUserManager<ApplicationUserManager>();

        private IAuthenticationManager AuthenticationManager =>
            HttpContext.GetOwinContext().Authentication;

        #endregion

        #region Public methods

        #region Register()

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        #endregion

        #region Register(RegisterModel model)

        [HttpPost]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser
                {
                    //Number = _applicationContext.Users.Count() + 1,
                    Name = model.Name,
                    Patronymic = model.Patronymic,
                    Surname = model.Surname,
                    Email = model.Email.ToLower(),
                    UserName = model.UserName.ToLower()
                };

                IdentityResult result =
                    await UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    if (user.UserName == "decanat")
                    {
                        _applicationContext.Roles.Add(
                            new IdentityRole(
                                "decanat"));

                        _applicationContext.SaveChanges();

                        await UserManager.AddToRoleAsync(user.Id, "decanat");
                    }

                    return RedirectToAction("Login", "Account");
                }

                foreach (string error in result.Errors)
                {
                    ModelState.AddModelError("", error);
                }
            }

            return View(model);
        }

        #endregion

        #region Login(string returnUrl = null)

        [HttpGet]
        public ActionResult Login(string returnUrl = null)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        #endregion

        #region Login(LoginModel model, string returnUrl)

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user =
                    await UserManager.FindAsync(model.UserName, model.Password);

                if (user == null)
                {
                    ModelState.AddModelError("", "Неверный логин или пароль");
                }
                else
                {
                    ClaimsIdentity claim = await UserManager.CreateIdentityAsync(user,
                        DefaultAuthenticationTypes.ApplicationCookie);

                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(
                        new AuthenticationProperties {IsPersistent = true}, claim);

                    if (string.IsNullOrWhiteSpace(returnUrl))
                    {
                        return RedirectToAction("Index", "Home");
                    }

                    return Redirect(returnUrl);
                }
            }

            ViewBag.returnUrl = returnUrl;
            return View(model);
        }

        #endregion

        [HttpGet]
        public ActionResult Restore()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Restore(RestoreModel model)
        {
            ApplicationUser user = UserManager.FindByEmail(model.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Пользователь не найден");
            }

            if (ModelState.IsValid)
            {
                model.Id = user.Id;
                string token = UserManager.GeneratePasswordResetToken(user.Id);

                string callbackUrl = Url.Action("RestoreConfirm", "Account",
                    new {model.Id, Code = token, model.Email}, Request.Url.Scheme);

                UserManager.SendEmail(user.Id, "Сброс пароля",
                    "Для сброса пароля, перейдите по ссылке <a href=\"" + callbackUrl +
                    "\">сбросить</a>");

                return Content("Проверьте почту");
            }

            return View();
        }

        [HttpGet]
        public ActionResult RestoreConfirm(RestoreModel model)
        {
            return View(model);
        }

        [HttpPost]
        [ActionName("RestoreConfirm")]
        public ActionResult RestoreConfirmValidate(RestoreModel model)
        {
            IdentityResult result =
                UserManager.ResetPassword(model.Id, model.Code, model.NewPassword);

            if (result.Succeeded)
            {
                return RedirectToAction("Login");
            }

            foreach (string error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }

            return View(model);
        }


        #region Logout()

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        #endregion

        [Authorize]
        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            IdentityResult result = UserManager.ChangePassword(User.Identity.GetUserId(),
                model.OldPassword,
                model.NewPassword);

            foreach (string error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (result.Succeeded)
            {
                return Content("Пароль сменен");
            }

            ModelState.AddModelError("", "Во время запроса произошла ошибка");
            return View(model);
        }

        #endregion
    }
}