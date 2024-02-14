using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ChefsDished.Models;

namespace ChefsDished.Controllers;

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
        List<Chef> Chefs = _context.Chefs.Include(chef => chef.CreatedDishes).ToList();
       
        

        return View(Chefs);
    }
    
    [HttpGet("/Chefs/New")]
    public IActionResult AddChef()
    {
    
        return View();
    }

    [HttpPost]
    public IActionResult CreateChef(Chef NewChef)
    {
        if(ModelState.IsValid)
        {
            _context.Add(NewChef);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View("AddChef");
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
}
