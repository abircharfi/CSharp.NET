using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;

namespace CRUDelicious.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

    public HomeController(ILogger<HomeController> logger,MyContext context)
    {
        _logger = logger;
        _context = context;
    }

 

    public IActionResult Index()
    {
        List<Dish> AllDishes = _context.Dishes.ToList();
        return View(AllDishes);
    }

    // add dish view
    public IActionResult AddDish()
    {
        return View();
    }
    // Here we take infos from the form to create new Dish
    [HttpPost]
    public IActionResult Create(Dish newDish)
    {
      if(ModelState.IsValid)
      {
         _context.Add(newDish);
         _context.SaveChanges();
         return RedirectToAction("Index");
      }
      else
      {
        return View("AddDish");
      }
      
    }

    // display one dish
[HttpGet("DisplayOne")]
public IActionResult DisplayOne(int id)
{
    Dish? dish = _context.Dishes.FirstOrDefault(d => d.DishId == id);
    return View("DisplayOneDish", dish);
}

// can we make one signe action here?
[HttpGet("EditDish")]
public IActionResult EditDish(int id )
{
  Dish? dish = _context.Dishes.FirstOrDefault(d => d.DishId == id);
  return View("EditDish",dish);
}

[HttpPost]
public IActionResult Update(Dish newDish)
{

if(ModelState.IsValid)
      {
Dish? OldDish = _context.Dishes.FirstOrDefault(d => d.DishId == newDish.DishId);
OldDish.Name = newDish.Name;
OldDish.Tastiness=newDish.Tastiness;
OldDish.Chef = newDish.Chef;
OldDish.Calories = newDish.Calories;
OldDish.Description= newDish.Description;
OldDish.UpdatedAt=newDish.UpdatedAt;
_context.SaveChanges();
return RedirectToAction("Index");
      }
return View("EditDish");


}

[HttpPost]
public IActionResult Delete(int id)
{
    System.Console.WriteLine(id);
    Dish? DishToDelete = _context.Dishes.SingleOrDefault(d => d.DishId == id);
    _context.Dishes.Remove(DishToDelete);
    _context.SaveChanges();
     return RedirectToAction("Index");
}
    




    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
