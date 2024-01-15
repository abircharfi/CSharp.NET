
using Microsoft.AspNetCore.Mvc;

namespace RazorFun.controllers;
public class Razor : Controller
{
    [HttpGet ("")]

    public ViewResult Index()
    {
        return View("Index");
    }
}