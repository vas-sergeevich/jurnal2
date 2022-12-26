using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Pagen.Models;
using Pagen.Models.Identity;

namespace Pagen.Controllers
{
    [Authorize(Roles = "decanat")]
    public class DecanatController : Controller
    {
        #region Readonly fields

        private readonly ApplicationContext
            _applicationContext = new ApplicationContext();

        #endregion

        #region Public methods

        [HttpGet]
        public ActionResult AllStudents()
        {
            return View(_applicationContext.Students.ToList());
        }

        [HttpGet]
        public ActionResult DeleteStudent(int id)
        {
            Student student = _applicationContext.Students.Find(id);
            if (student == null)
            {
                return Content("Студент не найден.");
            }

            _applicationContext.Entry(student).State =
                EntityState.Deleted;

            _applicationContext.SaveChanges();

            return RedirectToAction("AllStudents");
        }

        [HttpGet]
        public ActionResult EditStudent(int id)
        {
            Student student = _applicationContext.Students.Find(id);
            if (student == null)
            {
                return Content("Студент не найден.");
            }

            return View(student);
        }

        [HttpPost]
        public ActionResult EditStudent(Student student)
        {
            if (student == null)
            {
                return Content("Студент не создан.");
            }

            _applicationContext.Entry(student).State =
                EntityState.Modified;

            _applicationContext.SaveChanges();

            return RedirectToAction("AllStudents");
        }

        [HttpGet]
        public ActionResult CreateStudent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateStudent(Student student)
        {
            if (student == null)
            {
                return Content("Студент не создан.");
            }

            _applicationContext.Students.Add(student);

            _applicationContext.SaveChanges();

            return RedirectToAction("AllStudents");
        }

        [HttpGet]
        public ActionResult ShowProfessors()
        {
            return View(_applicationContext.Users.ToList());
        }

        [HttpGet]
        public ActionResult AddSubject()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSubject(Subject subject)
        {
            if (subject == null)
            {
                return Content("Предмет не создан.");
            }

            subject.ApplicationUserId = _applicationContext.Users
                .FirstOrDefault(user => user.UserName == subject.ApplicationUserId)?.Id;

            if (string.IsNullOrEmpty(subject.ApplicationUserId))
            {
                ModelState.AddModelError("", "Преподаватель не найден!");
                return RedirectToAction("AddSubject", subject);
            }

            _applicationContext.Subjects.Add(subject);

            _applicationContext.SaveChanges();

            return RedirectToAction("ShowSubjects");
        }

        [HttpGet]
        public ActionResult ShowSubjects()
        {
            return View(_applicationContext.Subjects.ToList());
        }

        [HttpGet]
        public ActionResult DeleteSubject(int id)
        {
            Subject subject = _applicationContext.Subjects.Find(id);
            if (subject == null)
            {
                return Content("Предмет не найден.");
            }

            _applicationContext.Entry(subject).State =
                EntityState.Deleted;

            _applicationContext.SaveChanges();
            return RedirectToAction("ShowSubjects");
        }

        #endregion
    }
}