using Microsoft.AspNetCore.Mvc;

namespace PortfolioII.Controllers;

public class PortfolioController : Controller
{
    [HttpGet("")]
        public ViewResult Index()
        {
            SetCurrentPage("Home");
            return View();
        }

        [HttpGet("/contact")]
        public ViewResult Contact()
        {
            SetCurrentPage("Contact");
            return View();
        }

        [HttpGet("/projects")]
        public ViewResult Projects()
        {
            SetCurrentPage("Projects");
           return View();
        }

        private void SetCurrentPage(string page)
        {
            ViewBag.CurrentPage = page;
        }
    }


