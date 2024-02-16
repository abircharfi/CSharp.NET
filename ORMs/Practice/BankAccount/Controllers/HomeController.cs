
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BankAccount.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;


namespace BankAccount.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context= context;
    }

    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult CreateUserForm(User newUser)
    {
     if (ModelState.IsValid)
     {
            
            if(_context.Users.Any(u => u.Email == newUser.Email))
            {
                ModelState.AddModelError("email","mail exist!");
                return View("Index");
                
            }
             HttpContext.Session.GetInt32("newUser.UserId");
             var hasher = new PasswordHasher<User>();
             newUser.Password = hasher.HashPassword(newUser,newUser.Password);
             _context.Add(newUser);
             _context.SaveChanges();
             return RedirectToAction("Success",new { id = newUser.UserId });

     }
   
     return View("Index");
    }
    [HttpPost]
    public IActionResult LoginUserForm(LoginUser logUser)
    {
      if (ModelState.IsValid)
      {
        var UserIndb = _context.Users.FirstOrDefault(u => u.Email == logUser.LoginEmail);
        if(UserIndb == null)
        {
            ModelState.AddModelError("LoginEmail","Invalid email adress");
            return View("Index");
        }
        var hasher = new PasswordHasher<LoginUser>();

        var ComparePassword = hasher.VerifyHashedPassword(logUser,UserIndb.Password,logUser.LoginPassword);
        
        if(ComparePassword == 0)
        {
            ModelState.AddModelError("LoginPassword","Invalid Password");
            return View("Index");
        }
        HttpContext.Session.SetInt32("id",UserIndb.UserId);
        return RedirectToAction("Success",new { id = UserIndb.UserId });

        }

     return View("Index");
    }


   [HttpGet("account/{id}")]
public IActionResult Success(int id)
{
    if(HttpContext.Session.GetInt32("id")!= null)
    {
    var userWithTransactions = _context.Users.Include(u => u.Transactions).FirstOrDefault(u => u.UserId == id);
    if (userWithTransactions == null)
    {
      
         return View();
    }
    
    ViewBag.User = userWithTransactions;
    ViewBag.Balance = userWithTransactions.Transactions.Sum(t => t.Amount);

    return View();
    }
    ModelState.AddModelError("LoginPassword","You must be logged in !");
    return View("Index");
}

    
    [HttpPost]
    public IActionResult CreateTransaction(Transaction NewTransaction,int UserselId)
   {
   
           var user = _context.Users.FirstOrDefault(c => c.UserId == UserselId);
           ViewBag.User = user;
           if (user != null)
           {
             NewTransaction.Tasker = user; 
             NewTransaction.Tasker.UserId = UserselId;
             _context.Transactions.Add(NewTransaction);
             _context.SaveChanges(); 

             ViewBag.Balance=ViewBag.Balance+NewTransaction.Amount;
             
              return RedirectToAction("Success",new { id = UserselId });
            }
            return RedirectToAction("Success",new { id = UserselId });
   }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
