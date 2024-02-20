using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;
using System.Xml.Serialization;
using System.Net;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using WeddingPlanner.Models;

namespace WeddingPlanner.Controllers;

public class WeddingController : Controller
{
   
    private MyContext _context;

    public WeddingController( MyContext context)
    {
        _context=context;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("wedding/new")]
    public IActionResult AddWedding()
    {
        var UserInSession = HttpContext.Session.GetInt32("UserId");
        ViewBag.currentUserId = UserInSession;
        ViewBag.user=_context.Users.FirstOrDefault(u => u.UserId == UserInSession);
        return View();
    }

    [HttpPost("wedding/new")]
public IActionResult CreateWedding(Wedding NewWedding)
{
    if (ModelState.IsValid)
    {
        _context.Add(NewWedding);
        _context.SaveChanges();

        var newAttendance = new Attendance
        {
            UserId = NewWedding.UserId, 
            WeddingId = NewWedding.WeddingId 
        };

        _context.Add(newAttendance);
        _context.SaveChanges();

        return RedirectToAction("DisplayWedding", new { WedId = NewWedding.WeddingId, userId = newAttendance.UserId });

    }

    return View("AddWedding");
}


    [HttpGet("wedding/{WedId}/{userId}")]
      public IActionResult DisplayWedding(int WedId, int userId)
    {
        var userInSession = HttpContext.Session.GetInt32("UserId");
        if(userInSession != null)
        {
        
        ViewBag.user = _context.Users.FirstOrDefault(u=>u.UserId ==userId );
        Wedding wedding = _context.Weddings.Include(wed => wed.Creator).Include(atennd=>atennd.Guests).FirstOrDefault(wed => wed.WeddingId == WedId);
        List<User> Guests = _context.Attendances.Where(a => a.WeddingId == WedId).Include(a => a.User).Select(a => a.User).ToList();
        ViewBag.Guests=Guests;
        return View(wedding);
        }
        return RedirectToAction("Index", "Home");
    }

[HttpGet("wedding/reserv/{WedId}/{userId}")]
    public IActionResult Reserv(int WedId, int userId)
    {
        var userInSession = HttpContext.Session.GetInt32("UserId");
        if(userInSession != null)
        {
        var newAttendance = new Attendance
        {
            UserId = userId, 
            WeddingId = WedId 
        };

        _context.Add(newAttendance);
        _context.SaveChanges();

        return RedirectToAction("Success", "Home");
        }
        return RedirectToAction("Index", "Home");
    }

[HttpGet("wedding/Unreserv/{WedId}/{userId}")]
    public IActionResult UnReserv(int WedId, int userId)
{
    var userInSession = HttpContext.Session.GetInt32("UserId");
        if(userInSession != null)
        {
         var Unreserv = _context.Attendances.FirstOrDefault(u => u.UserId == userId && u.WeddingId == WedId);
         System.Console.WriteLine(Unreserv);
         if (Unreserv != null)
        {
        _context.Attendances.Remove(Unreserv);
        _context.SaveChanges();
        return RedirectToAction("Success", "Home");
        }
        }
    return RedirectToAction("Index", "Home");
}


   [HttpGet("wedding/delete/{WedId}")]
public IActionResult DeleteWedding(int WedId)
{
    var userInSession = HttpContext.Session.GetInt32("UserId");
    
        if(userInSession != null)
        {
        var weddingToDelete = _context.Weddings.FirstOrDefault(w => w.WeddingId == WedId);
        if (weddingToDelete != null)
        {
        _context.Weddings.Remove(weddingToDelete);
        _context.SaveChanges();
        return RedirectToAction("Success", "Home");
        }
        return RedirectToAction("Index", "Home");
    }
    return RedirectToAction("Index", "Home");
}



}