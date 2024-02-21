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

    [HttpGet("/weddings")]

//---------------------------------------- success action 

public IActionResult Success()
{
    if (!IsUserLoggedIn()) return RedirectToIndex();

    var userInSession=HttpContext.Session.GetInt32("UserId");
    var pastWedding = _context.Weddings.Where(wed => wed.WeddDate < DateTime.Now).ToList();
    if (pastWedding != null)
    {       
    foreach (var item in pastWedding)
        {
            List<Attendance> relatedAttendances = _context.Attendances.Where(a => a.WeddingId == item.WeddingId).ToList();
            foreach (Attendance a in relatedAttendances.ToList())
            {
                
                    _context.Attendances.Remove(a);
                    _context.SaveChanges();

            }
            _context.Weddings.Remove(item);
            _context.SaveChanges();

        }
    }
    var weddings = _context.Weddings.Include(wed => wed.Guests).ThenInclude(attend => attend.User).Where(wed => wed.WeddDate > DateTime.Now).ToList();

    var user = _context.Users.FirstOrDefault(u => u.UserId == userInSession);
    ViewBag.user = user;

    var userAttendances = _context.Attendances.Where(a => a.UserId == userInSession).Select(a => a.WeddingId).ToList();
    ViewBag.userAttendances = userAttendances;

    return View(weddings);
}

//----------------------------------------- add wedding view

    [HttpGet("wedding/new")]
    public IActionResult AddWedding()
    {
    if (!IsUserLoggedIn()) return RedirectToIndex();
        var UserInSession = HttpContext.Session.GetInt32("UserId");
        ViewBag.currentUserId = UserInSession;
        var user =_context.Users.FirstOrDefault(u => u.UserId == UserInSession);
        ViewBag.user=user;
        return View();
    }

// -------------------------------------------CreateWedding

    [HttpPost]
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
    var UserInSession = HttpContext.Session.GetInt32("UserId");
    ViewBag.currentUserId = UserInSession;
    var user =_context.Users.FirstOrDefault(u => u.UserId == UserInSession);
    ViewBag.user = user;
    return View("AddWedding");
    }


//---------------------------------------------DisplayWedding

    [HttpGet("wedding/{WedId}/{userId}")]
      public IActionResult DisplayWedding(int WedId, int userId)
    {
         if (!IsUserLoggedIn()) return RedirectToIndex();
        
        var user = _context.Users.FirstOrDefault(u=>u.UserId ==userId );
          
        ViewBag.user = user;
        Wedding wedding = _context.Weddings.Include(wed => wed.Creator).Include(atennd=>atennd.Guests).FirstOrDefault(wed => wed.WeddingId == WedId);
        List<User> Guests = _context.Attendances.Where(a => a.WeddingId == WedId).Include(a => a.User).Select(a => a.User).ToList();
        ViewBag.Guests=Guests;
        return View(wedding);
    
    }

//-----------------------------------------------Reserv wedding

[HttpGet("wedding/reserv/{WedId}/{userId}")]
        public IActionResult Reserv(int WedId, int userId)
        {
            if (!IsUserLoggedIn()) return RedirectToIndex();
            ReserveOrUnreserveAttendance(WedId, userId, true);

            return RedirectToAction("Success");
        }

//-----------------------------------------------UnReserv wedding

        [HttpGet("wedding/Unreserv/{WedId}/{userId}")]
        public IActionResult UnReserv(int WedId, int userId)
        {
            if (!IsUserLoggedIn()) return RedirectToIndex();
            ReserveOrUnreserveAttendance(WedId, userId, false);

            return RedirectToAction("Success");
        }


//------------------------------------------------DeleteWedding

   [HttpGet("wedding/delete/{WedId}")]
public IActionResult DeleteWedding(int WedId)
{
    if (!IsUserLoggedIn()) return RedirectToIndex();
    var weddingToDelete = _context.Weddings.FirstOrDefault(w => w.WeddingId == WedId);
        if (weddingToDelete != null)
        {
            List<Attendance> relatedAttendances = _context.Attendances.Where(a => a.WeddingId == WedId).ToList();
            foreach (Attendance a in relatedAttendances.ToList())
            {
                
                    _context.Attendances.Remove(a);
                    _context.SaveChanges();

            }
            _context.Weddings.Remove(weddingToDelete);
            _context.SaveChanges();
            return RedirectToAction("Success");
        }
    return RedirectToAction("Index", "Home");
    }


// -----------------------------ReserveOrUnreserveAttendance method 
    
     private void ReserveOrUnreserveAttendance(int WedId, int userId, bool reserve)
        {
            if (reserve)
            {
                _context.Add(new Attendance { UserId = userId, WeddingId = WedId });
            }
            else
            {
                var attendance = _context.Attendances.FirstOrDefault(u => u.UserId == userId && u.WeddingId == WedId);
                if (attendance != null)
                {
                    _context.Attendances.Remove(attendance);
                }
            }
            _context.SaveChanges();
        }

//---------------------------------IsUserLoggedIn method
    private bool IsUserLoggedIn()
        {
            return HttpContext.Session.GetInt32("UserId") != null;
        }

    private IActionResult RedirectToIndex()
        {
            ModelState.AddModelError("LoginPassword", "You should connect!");
            return RedirectToAction("Index", "Home");
        }
    
}




