using System.Linq;
using System.Web.Mvc;
using Pagen.Models;
using Pagen.Models.Identity;

namespace Pagen.Controllers
{
    public class HomeController : Controller
    {
        #region Readonly fields

        private readonly ApplicationContext
            _applicationContext = new ApplicationContext();

        #endregion

        #region Public methods

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SearchUser(string group, string surname, string name)
        {
            Student student = _applicationContext.Students.FirstOrDefault(s =>
                s.Group.Contains(group) && s.Surname.Contains(surname) &&
                s.Name.Contains(name));

            if (student != null)
            {
                ViewData["existStudent"] = true;
                ViewData["student"] = student;
                return View(_applicationContext.Grades
                    .Where(g => g.StudentId == student.Id).ToList());
            }

            return RedirectToAction("Index");
        }

        #endregion
    }
}