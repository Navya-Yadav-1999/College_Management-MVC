using CollegeManagement.Models.DataModel;
using CollegeManagement.Models.ViewModel;
using CollegeManagement.Service;
using Microsoft.AspNetCore.Mvc;

namespace CollegeManagement.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherservice;
        public TeacherController(ITeacherService teacherService)
        {
            _teacherservice = teacherService;
        }
        public IActionResult Index()
        {
            return View("~/Views/Admin/Teacher/Index.cshtml");
        }
        public ActionResult Register()
        {
            return View("~/Views/Admin/Teacher/Register.cshtml");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(TeacherViewModel teacher)
        {
            string message = "";
            if (ModelState.IsValid)
            {
                _teacherservice.Save(teacher);
                return RedirectToAction("Teachers");

            }
            else
            {
                message = "Teacher Not Added";
            }
            return Content(message);



        }
        public ActionResult Status()
        {
            return View();
        }
        public ActionResult Teachers()
        {
            _teacherservice.Details();
            ViewData.Model = _teacherservice.Details();
            return View("~/Views/Admin/Teacher/Teachers.cshtml");

        }
        public ActionResult Edit(int Id)
        {
            var teacher = _teacherservice.Get(Id);
            return View("~/Views/Admin/Teacher/Edit.cshtml", teacher);
        }
        public ActionResult EditPost(Teacher teacher)
        {
            var teac = _teacherservice.Edit(teacher);
            return RedirectToAction("Teachers", "Admin");

        }
        public ActionResult Delete(int Id)
        {
            _teacherservice.Delete(Id);
            return RedirectToAction("Teachers", "Admin");

        }
        public ActionResult Teacher(int userid)
        {
            ViewBag.userId = TempData["user"];
            userid = ViewBag.userId;
            _teacherservice.GetTeacher(userid);
            ViewData["student"] = _teacherservice.GetTeacher(userid);
            return View("~/Views/Admin/Teacher/Teacher.cshtml");

        }
        public ActionResult TeacherSearch()
        {
            return View("~/Views/Admin/Teacher/TeacherSearch.cshtml");
        }
        [HttpGet]
        public ActionResult TeacherSearch(string terSearch)
        {
            ViewData["GetTeacherdetails"] = terSearch;

            _teacherservice.GetTeacher(terSearch);
            ViewData.Model = _teacherservice.GetTeacher(terSearch);
            return View("~/Views/Admin/Teacher/Teachers.cshtml");

        }
    }
}
