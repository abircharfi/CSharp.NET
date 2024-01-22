using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DojoSurveywithValidation.Models;

namespace DojoSurveywithValidation.Controllers;

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


      [HttpPost]
      public IActionResult Submission(Survey yourSurvey)
      {
          if (ModelState.IsValid)
          { 
            Surveys.Add(yourSurvey);
            return RedirectToAction("Results" );
          }
          else
          {
            return View("Index",yourSurvey);
          }   
       }

      [HttpGet("/result")]
      public IActionResult Results()
      {
         return View(Surveys);
      }

}
