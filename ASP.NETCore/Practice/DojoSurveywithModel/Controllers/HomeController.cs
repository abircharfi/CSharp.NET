using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DojoSurveywithModel.Models;

namespace DojoSurveywithModel.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    public static List<Survey> Surveys = new List<Survey>();

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
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



    [HttpPost("addSurvey")]
public IActionResult Submission(Survey yourSurvey)
{
    
        Surveys.Add(yourSurvey);
        Console.WriteLine(yourSurvey.yourName);
        return RedirectToAction("Result");
    
}

[HttpGet("results")]
public IActionResult Result()
{
    return View(Surveys);
}

}
