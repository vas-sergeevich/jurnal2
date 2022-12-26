using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Pagen.Models.Identity;

namespace Pagen.Models
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        #region Properties

        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Grade> Grades { get; set; }

        #endregion

        #region Constructor

        public ApplicationContext() : base("PagenContext")
        {
        }

        #endregion

        #region Public methods

        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }

        #endregion
    }
}