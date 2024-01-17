
using Microsoft.AspNetCore.Mvc;

namespace TimeDisplay
{
   public class DateTime : Controller
   {
   [HttpGet("")]
   public ViewResult Index()
   {
    return View();
   }
   }
}