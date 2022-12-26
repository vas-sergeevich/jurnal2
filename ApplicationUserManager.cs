using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.DataProtection;

namespace Pagen.Models
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        #region Public methods

        public ApplicationUserManager(IUserStore<ApplicationUser> store) : base(store)
        {
            PasswordValidator = new PasswordValidator
            {
                RequireDigit = true,
                RequiredLength = 6,
                RequireLowercase = true,
                RequireNonLetterOrDigit = false,
                RequireUppercase = false
            };

            UserValidator = new UserValidator<ApplicationUser>(this)
            {
                AllowOnlyAlphanumericUserNames = true,
                RequireUniqueEmail = true
            };

            EmailService = new EmailService();

            DpapiDataProtectionProvider provider =
                new DpapiDataProtectionProvider("ASP.NET IDENTITY");

            UserTokenProvider =
                new DataProtectorTokenProvider<ApplicationUser>(
                        provider.Create("EmailConfirmation"))
                    {TokenLifespan = TimeSpan.FromHours(1)};
        }

        public static ApplicationUserManager Create(
            IdentityFactoryOptions<ApplicationUserManager> options,
            IOwinContext context)
        {
            ApplicationContext dataBase = context.Get<ApplicationContext>();
            ApplicationUserManager manager =
                new ApplicationUserManager(new UserStore<ApplicationUser>(dataBase));

            return manager;
        }

        #endregion
    }
}