using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChefsDished.Models;

namespace ChefsDished.Controllers;

public class DishController : Controller
{
    private readonly MyContext _context;

    public DishController(MyContext context)
    {
      _context = context ;
    }
    [HttpGet("/dishes")]
    public IActionResult Index()
    {
        List<Dish> Dishes = _context.Dishes.Include(dish => dish.Creator).ToList();
       
        

        return View(Dishes);
    }

    [HttpGet("/Dishes/New")]
    public IActionResult AddDish()
    {
    
         var chefs = _context.Chefs.ToList();
         ViewBag.Chefs = chefs; 
         return View();
    }

    [HttpPost("/Dishes/New")]
    public IActionResult CreateDish(Dish NewDish, int selectedChefId)
    {

        if(ModelState.IsValid)
        { 
            var chef = _context.Chefs.FirstOrDefault(c => c.ChefId == selectedChefId);
            if (chef != null)
            {
            NewDish.Creator = chef;
            _context.Add(NewDish);
            _context.SaveChanges();
            return RedirectToAction("Index");
            }
            else
            {
            ModelState.AddModelError("", "Chef not found.");
            }
        }
        ViewBag.Chefs = _context.Chefs.ToList();
        return View("AddDish");
    }
    

}