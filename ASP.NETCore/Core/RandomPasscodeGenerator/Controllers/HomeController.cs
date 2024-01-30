using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RandomPasscodeGenerator.Models;
using Microsoft.AspNetCore.Http;
//using sessionLecture.Models;

namespace RandomPasscodeGenerator.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

   

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<char> Passcode = new List<char>();
        int Counter = HttpContext.Session.GetInt32("Counter") ?? 0;
        ViewBag.Counter = Counter;
         return View(Passcode);
    }

    public IActionResult Privacy()
    {
        return View();
    }


public IActionResult Random()
{
    Random rand = new Random();

   int Counter = (HttpContext.Session.GetInt32("Counter") ?? 0) + 1;
        HttpContext.Session.SetInt32("Counter", Counter);  
          
    List<char> list = new List<char>(){'1','2','3','4','5','6','7','8','9'};

    for (char c = 'A'; c <= 'Z'; c++)
    {
      list.Add(c);
    }

    List<char> passcode = new List<char>();

    for(int val = 0; val < 14; val++)
    {

    int indice = rand.Next(0,list.Count);
    passcode.Add(list[indice]);

    }

    // foreach (var item in passcode)
    // {
    // Console.WriteLine(item);   
    // }

    ViewBag.Counter = Counter;

    return View("Index", passcode);

}


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
