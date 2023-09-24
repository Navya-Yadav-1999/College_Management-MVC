using CollegeManagement.Models;
using CollegeManagement.Models.DataModel;
using CollegeManagement.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace CollegeManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public HomeController(IUserService userService, ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public ActionResult Loginpage()
        {
            return View();
        }
        public ActionResult SignIn(User user)
        {
            var userData = _httpContextAccessor.HttpContext.Session.GetString("userData");
            if (userData != null)
            {
                _httpContextAccessor.HttpContext.Session.Clear();
            }
            var us = _userService.Get(user.EmailId);
            if (_userService.IsValidUser(user.EmailId, user.UserPassword))
            {
                _httpContextAccessor.HttpContext.Session.SetString("userData", us.EmailId);

                TempData["user"] = us.Id;

                switch (us.UserType)
                {
                    case "Admin":
                        return RedirectToAction("Index", "Admin");
                    case "Student":
                        return RedirectToAction("Student", "Student");
                    case "Teacher":
                        return RedirectToAction("Teacher", "Teacher");

                }
            }
            else
            {
                ViewBag.Message = "Invalid Username Or Password";

            }
            return View("Index");


        }
    }
}