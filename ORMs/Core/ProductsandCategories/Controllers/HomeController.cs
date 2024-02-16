using System.Security.Cryptography;
using System.Reflection.Emit;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProductsandCategories.Models;
using Microsoft.EntityFrameworkCore;


namespace ProductsandCategories.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        ViewBag.AllProducts = _context.Products.ToList();
        return View();
    }

    [HttpPost]
    public IActionResult CreateProduct(Product newProduct)
    {
        ViewBag.AllProducts = _context.Products.ToList();
        if(ModelState.IsValid)
        {
        _context.Products.Add(newProduct);
        _context.SaveChanges();
        return RedirectToAction("Index");
        }
        return View("Index");

    }
   [HttpGet("product/{id}", Name = "Details")]
public IActionResult Details(int id)
{
    var product = _context.Products.Include(p => p.ProductAssociated).ThenInclude(ass => ass.AssociatedCategory).FirstOrDefault(pro => pro.ProductId == id);
    // select all the categories in the product
    var associatedCategoryIds = product.ProductAssociated.Select(ass => ass.CategoryId).ToList();
    // Withdraw associatedCategoryIds from the categories to sent
    var categories = _context.Categories.Where(c => !associatedCategoryIds.Contains(c.CategoryId)).ToList();

    ViewBag.product = product;
    return View(categories);
}


    [HttpPost]
public IActionResult AddCategoryToProduct(Association newAssociation)
{


    if (ModelState.IsValid)
        {
            _context.Add(newAssociation);
            _context.SaveChanges();
            return RedirectToAction("Details", new { id = newAssociation.ProductId });
        }
        return View("Details");
}
// category actions 
    
    [HttpGet("Categories")]
    public IActionResult Categories()
    {
         ViewBag.AllCategories = _context.Categories.ToList();
        return View();
    }


    [HttpPost]
    public IActionResult CreateCategory(Category newCategory)
    {
        ViewBag.AllCategories = _context.Categories.ToList();
        if(ModelState.IsValid)
        {
        _context.Categories.Add(newCategory);
        _context.SaveChanges();
        return RedirectToAction("Categories");
        }
        return View("Categories");

    }

    [HttpGet("category/{id}", Name = "DetailsCategory")]
public IActionResult DetailsCategory(int id)
{
    var category = _context.Categories.Include(c => c.CategoryAssociated).ThenInclude(ass => ass.AssociatedProduct).FirstOrDefault(cat => cat.CategoryId == id);
 
    var associatedProductsIds = category.CategoryAssociated.Select(ass => ass.ProductId).ToList();
 
    var products = _context.Products.Where(p => !associatedProductsIds.Contains(p.ProductId)).ToList();

    ViewBag.category = category;
    return View(products);
}


    [HttpPost]
   public IActionResult AddProductToCategory(Association newAssociation)
   {


    if (ModelState.IsValid)
        {
            _context.Add(newAssociation);
            _context.SaveChanges();
            return RedirectToAction("DetailsCategory", new { id = newAssociation.CategoryId });
        }
        return View("DetailsCategory");
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
