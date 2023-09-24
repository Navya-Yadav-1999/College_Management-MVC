using CollegeManagement.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace CollegeManagement.Controllers
{
    public class AdminController : Controller
    {
       
        private readonly IStudentService _studentservice;
        private readonly ITeacherService _teacherservice;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AdminController(IStudentService studentService, ITeacherService teacherService, IHttpContextAccessor httpContextAccessor)
        {
            _studentservice = studentService;
            _teacherservice = teacherService;
            _httpContextAccessor = httpContextAccessor;

        }
        public IActionResult Index()
        {
            var userData = _httpContextAccessor.HttpContext.Session.GetString("userData");
            if (userData != null)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Students()
        {
            _studentservice.Details();
            ViewData.Model = _studentservice.Details();
            return View("~/views/Admin/GetStudentDetails.cshtml");

        }
        public ActionResult Teachers()
        {
            _teacherservice.Details();
            ViewData.Model = _teacherservice.Details();
            return View("~/Views/Admin/GetTeacherDetails.cshtml");

        }
    }
}
