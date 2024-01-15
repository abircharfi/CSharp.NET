using Microsoft.AspNetCore.Mvc;
namespace PortfolioI.Controllers
{
public class IndexController : Controller 
{
    [HttpGet("")]
    public string Index()
    {
        return "This is My Index";
    }

    [HttpGet("/projects")]
    public string project()
    {
        return "These are my projects";
    }
    [HttpGet("/contact")]
    public string contact()
    {
        return "This my contact";
    }
}
}