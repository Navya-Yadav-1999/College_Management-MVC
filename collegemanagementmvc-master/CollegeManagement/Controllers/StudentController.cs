using CollegeManagement.DataBase;
using CollegeManagement.Models.DataModel;
using CollegeManagement.Models.ViewModel;
using CollegeManagement.Service;
using Microsoft.AspNetCore.Mvc;

namespace CollegeManagement.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentservice;
        private readonly CollegeManagementContext _db;
        public StudentController(IStudentService studentService, CollegeManagementContext db)
        {
            _studentservice = studentService;
            _db = db;

        }
        public IActionResult Index()
        {
            return View("~/Views/Admin/Student/Index.cshtml");
        }
        public ActionResult Register()
        {
            return View("~/Views/Admin/Student/Register.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(StudentViewModel student)
        {
            string message = "";
            if (ModelState.IsValid)
            {
                _studentservice.Save(student);
                return RedirectToAction("Students", "Admin");

            }
            else
            {
                message = "Student Not Added";
            }
            return Content(message);



        }
        public ActionResult Status()
        {
            return View();
        }
        public ActionResult Students()
        {
            _studentservice.Details();
            ViewData.Model = _studentservice.Details();
            return View("~/views/Admin/Student/Students.cshtml");



        }
        public ActionResult StudentSearch()
        {
            return View("~/Views/Admin/Student/StudentSearch.cshtml");
        }
        [HttpGet]
        public ActionResult StudentSearch(string stdSearch)
        {
            ViewData["Getstudentdetails"] = stdSearch;

            _studentservice.GetStudent(stdSearch);
            ViewData.Model = _studentservice.GetStudent(stdSearch);
            return View("~/Views/Admin/Student/Students.cshtml");

        }

        public ActionResult Edit(int Id)
        {
            var student = _studentservice.Get(Id);
            return View("~/Views/Admin/Student/Edit.cshtml", student);
        }
        public ActionResult EditPost(Student student)
        {
            _studentservice.Edit(student);
            return RedirectToAction("Students", "Admin");

        }
        public ActionResult Delete(int Id)
        {
            _studentservice.Delete(Id);
            return RedirectToAction("Students", "Admin");
        }
        public ActionResult Student(int userid)
        {
            ViewBag.userId = TempData["user"];
            userid = ViewBag.userId;
            _studentservice.GetStudent(userid);
            ViewData["student"] = _studentservice.GetStudent(userid);
            return View("~/Views/Admin/Student/Student.cshtml");

        }
    }
}
