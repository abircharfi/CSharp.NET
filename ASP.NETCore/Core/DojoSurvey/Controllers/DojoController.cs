using Microsoft.AspNetCore.Mvc;


namespace DojoSurvey.Controllers;

public class Dojo : Controller
{
[HttpGet("")]
public ViewResult Form()
{
    return View();
}

 [HttpPost("/result")]
        public IActionResult Result(string yourName, string dojoLocation, string favoriteLanguage, string comments)
        {

            ViewBag.YourName = yourName;
            ViewBag.DojoLocation = dojoLocation;
            ViewBag.FavoriteLanguage = favoriteLanguage;
            ViewBag.Comments = comments;

            return View("Result");
        }

}