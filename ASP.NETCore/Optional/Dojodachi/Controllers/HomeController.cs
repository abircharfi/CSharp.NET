using System.IO.Pipes;
using System.Reflection.PortableExecutable;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Dojodachi.Models;

namespace Dojodachi.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    Pet myPet = new Pet();

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

     private Pet GetPetFromSession()
    {
        Pet sessionPet = HttpContext.Session.GetObjectFromJson<Pet>("Pet");
        return sessionPet ?? new Pet();
    }

    private void SavePetToSession(Pet pet)
    {
        HttpContext.Session.SetObjectAsJson("Pet", pet);
    }

    public IActionResult Index()
{
    Pet myPet = HttpContext.Session.GetObjectFromJson<Pet>("Pet") ?? new Pet();

    
    if (myPet.fullness >= 100 && myPet.happiness >= 100 && myPet.energy >= 100)
    {
        ViewBag.Won = true;
        ViewBag.message = "Congratulations! You Won!";
    }
    else if (myPet.fullness <= 0 || myPet.happiness <= 0)
    {
        ViewBag.Lost = true;
        ViewBag.message = "Your Dojodachi has passed away!";
    }
    else
    {
        
        if (TempData["message"] != null)
        {
            ViewBag.message = TempData["message"].ToString();
        }
    }

    return View(myPet);
}



    [HttpPost]
    public IActionResult Feed()
    {

        Pet myPet = GetPetFromSession();
        string message = myPet.feed();
        SavePetToSession(myPet);
        TempData["message"] = message;
    return RedirectToAction("Index");
    
    }

    [HttpPost]
    public IActionResult Play()
    {

        Pet myPet = GetPetFromSession();
        string message = myPet.play();
        SavePetToSession(myPet);
        TempData["message"] = message;
        System.Console.WriteLine(message);

    return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Work()
    {

        Pet myPet = GetPetFromSession();
        string message = myPet.work();
        SavePetToSession(myPet);
        TempData["message"] = message;

    return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Sleep()
    {

        Pet myPet = GetPetFromSession();
        string message = myPet.sleep();
        SavePetToSession(myPet);
        TempData["message"] = message;

    return RedirectToAction("Index");
    }


    [HttpPost]
    public IActionResult Restart()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
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
