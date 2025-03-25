using CheckboxDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CheckboxDemo.Controllers
{
    public class HomeController : Controller
    {
        private string _connectionString =
            @"Data Source=.\sqlexpress;Initial Catalog=CheckboxDemo;Integrated Security=True;TrustServerCertificate=true;";

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckboxDemo(string name, bool isAmazing)
        {
            return View(new CheckboxDemoViewModel
            {
                Name = name,
                IsAmazing = isAmazing
            });
        }

        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(Signup signup)
        {
            var db = new SignupDb(_connectionString);
            db.Add(signup);
            return Redirect("/home/signup");
        }
    }
}
