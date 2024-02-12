using System.Security.Authentication;
using System.Runtime.Versioning;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Win32.SafeHandles;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using LoginAndRegistration.Models;

namespace LoginAndRegistration.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
   // Register
    [HttpPost]
    public IActionResult CreateUserForm(User NewUser)
    {
      if(ModelState.IsValid)
      {
        if(_context.User.Any(u=>u.Email == NewUser.Email))

        {
            ModelState.AddModelError("Email","User already exist !");
            return View("Index");
        }
        
        PasswordHasher<User> Hasher = new PasswordHasher<User>();
        NewUser.Password = Hasher.HashPassword(NewUser, NewUser.Password);
        _context.Add(NewUser);
        _context.SaveChanges();
        var nwUser = _context.User.Add(NewUser).Entity;
        HttpContext.Session.SetString("Email", nwUser.Email);
        return RedirectToAction("Success");
        
      }

      return View("Index");
    }

    // Login

    [HttpPost]
    public IActionResult LoginUserForm(UserLogin exUser)
    {
        if(ModelState.IsValid)
        {
            var userInDB = _context.User.FirstOrDefault(u => u.Email == exUser.LoginEmail);
            if(userInDB == null)
            {
                ModelState.AddModelError("LoginEmail","Invalid Login");
                return View("Index");
            }
            var hasher = new PasswordHasher<UserLogin>();
            var ComparePassword = hasher.VerifyHashedPassword(exUser, userInDB.Password , exUser.LoginPassword);

            if (ComparePassword == 0)
            {
                ModelState.AddModelError("LoginPassword","Invalid Login");
                return View("Index");
            }
            HttpContext.Session.SetString("Email", userInDB.Email);
            return RedirectToAction("Success");
        }

        return View ("Index");
        
    }


    // Logout
    public IActionResult Logout()
        {
            
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
    }

    [HttpGet("/Success")]
    public IActionResult Success()
    {
        if(HttpContext.Session.GetString("Email") == null)
        {
            return RedirectToAction("Index");
        }
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
