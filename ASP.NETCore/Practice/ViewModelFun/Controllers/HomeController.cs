using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging; // Add this line for ILogger
using ViewModelFun.Models;
using System.Collections.Generic; // Add this line for List<T>

namespace ViewModelFun.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private List<User> users = new List<User>
        {
            new User { FirstName = "Moose", LastName = "Phillips" },
            new User { FirstName = "Sarah" },
            new User { FirstName = "Jerry" },
            new User { FirstName = "Rene", LastName = "Ricky" }
        };

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            string message = "Here is a message!";
            return View("Index", message);
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

        [HttpGet("/numbers")]
        public IActionResult Numbers()
        {
            int[] numbers = new int[] { 1, 2, 3, 10, 43, 5 };
            return View(numbers);
        }

        [HttpGet("/users")]
        public IActionResult Users()
        {
            return View(users);
        }

        [HttpGet("/user")]
        public IActionResult User()
        {
            User newUser = new User
            {
                FirstName = "Nichole",
                LastName = "King"
            };
            return View(newUser);
        }
    }
}
