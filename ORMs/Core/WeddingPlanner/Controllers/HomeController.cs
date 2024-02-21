using System;
using System.Security.Principal;
using System.Reflection.PortableExecutable;
using System.Xml.Serialization;
using System.Net;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using WeddingPlanner.Models;

namespace WeddingPlanner.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context=context;
    }

    public IActionResult Index()
    {
        return View();
    }

    // Register
    [HttpPost]
    public IActionResult CreateUserForm(User NewUser)
    {
      if(ModelState.IsValid)
      {
        if(_context.Users.Any(u=>u.Email == NewUser.Email))

        {
            ModelState.AddModelError("Email","User already exist !");
            return View("Index");
        }
        
        PasswordHasher<User> Hasher = new PasswordHasher<User>();
        NewUser.Password = Hasher.HashPassword(NewUser, NewUser.Password);
        _context.Add(NewUser);
        _context.SaveChanges();
        var nwUser = _context.Users.Add(NewUser).Entity;
        HttpContext.Session.SetInt32("UserId", nwUser.UserId);
        return RedirectToAction("Success","wedding");
        
      }

      return View("Index");
    }

    // Login

    [HttpPost]
    public IActionResult LoginUserForm(UserLogin exUser)
    {
        if(ModelState.IsValid)
        {
            var userInDB = _context.Users.FirstOrDefault(u => u.Email == exUser.LoginEmail);
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
            HttpContext.Session.SetInt32("UserId", userInDB.UserId);             
            return RedirectToAction("Success","wedding");
        }

        return View ("Index");
        
    }


    // Logout
    public IActionResult Logout()
        {
            
            HttpContext.Session.Clear();
            
            return RedirectToAction("Index");
    }

    


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
