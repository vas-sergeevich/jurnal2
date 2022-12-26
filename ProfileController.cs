using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Pagen.Models;
using Pagen.Models.Identity;

namespace Pagen.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        #region Readonly fields

        private readonly ApplicationContext
            _applicationContext = new ApplicationContext();

        #endregion

        #region Properties

        private ApplicationUserManager UserManager => HttpContext.GetOwinContext()
            .GetUserManager<ApplicationUserManager>();

        #endregion

        #region Private methods

        private ApplicationUser GetApplicationUser(string userName)
        {
            return UserManager
                .Users.FirstOrDefault(user => user.UserName == userName);
        }

        private string GetUserId(string userName)
        {
            return UserManager
                .Users.FirstOrDefault(user => user.UserName == userName)
                ?.Id;
        }

        #endregion

        #region Public methods

        [HttpGet]
        public ActionResult ShowSubjects()
        {
            string userId = GetUserId(User.Identity.Name);
            List<Subject> subjects = _applicationContext.Subjects
                .Where(s => s.ApplicationUserId == userId).ToList();

            return View(subjects);
        }


        public ActionResult OpenSubject(int subjectId)
        {
            string userId = GetUserId(User.Identity.Name);
            List<Grade> grades = _applicationContext.Grades.Where(g =>
                    g.Subject.ApplicationUserId == userId && g.SubjectId == subjectId)
                .ToList();

            Subject subject = _applicationContext.Subjects.Find(subjectId);
            if (subject == null)
            {
                return Content("Subject == null!");
                ;
            }

            ViewData["subjectName"] = subject.NameSubject;
            return View(grades);
        }

        [HttpGet]
        public ActionResult AddGrade()
        {
            string userId = GetUserId(User.Identity.Name);
            List<Subject> subjects = _applicationContext.Subjects
                .Where(s => s.ApplicationUserId == userId).ToList();

            ViewData["students"] =
                new SelectList(_applicationContext.Students, "Id", "FullName");

            ViewData["subjects"] = new SelectList(subjects, "Id", "NameSubject");

            ViewData["existSubjects"] = subjects.Count > 0;

            return View();
        }

        [HttpGet]
        public ActionResult DeleteGrade(int idGrade)
        {
            Grade grade = _applicationContext.Grades.Find(idGrade);
            if (grade != null)
            {
                _applicationContext.Entry(grade).State = EntityState.Deleted;
                _applicationContext.SaveChanges();
            }

            return RedirectToAction("ShowSubjects");
        }

        [HttpPost]
        public ActionResult AddGrade(int studentId, int subjectId, string rate,
            string discription)
        {
            _applicationContext.Grades.Add(new Grade
            {
                Rate = rate,
                StudentId = studentId,
                SubjectId = subjectId,
                Discription = discription
            });

            _applicationContext.SaveChanges();

            return RedirectToAction("OpenSubject", new {subjectId});
        }

        #endregion
    }
}