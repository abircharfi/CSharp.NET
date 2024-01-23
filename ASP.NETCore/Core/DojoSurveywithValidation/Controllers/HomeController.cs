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

   

      [HttpPost]
      public IActionResult Submission(Survey yourSurvey)
      {
          if (!ModelState.IsValid)
          { 
             
            return View("Index",yourSurvey);
          }
            Surveys.Add(yourSurvey);

          

            return RedirectToAction("Results" );
       }

      [HttpGet("/result")]
      public IActionResult Results()
      {
         return View(Surveys);
      }

     [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

    }

}
