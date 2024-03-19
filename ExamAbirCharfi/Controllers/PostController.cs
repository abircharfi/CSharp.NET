#pragma warning disable CS8600
#pragma warning disable CS8602
#pragma warning disable CS8604
#pragma warning disable CS8625
using System.Reflection.PortableExecutable;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExamAbirCharfi.Models;

namespace ExamAbirCharfi.Controllers;

public class PostController : Controller
{

    private MyContext _context;

    public PostController(MyContext context)
    {
        _context=context;
    }

   
   [HttpGet("posts")]
   public IActionResult Index(string searchMedium = null)
    {
     if (!IsUserLoggedIn()) return RedirectToIndex();
     var posts = _context.Posts.Include(p => p.Creator).Include(p=>p.Likers).ThenInclude(like => like.User).ToList();
     var User = HttpContext.Session.GetInt32("UserId");
     ViewBag.UserId = User;
     // search part 
     if (searchMedium != null)
         {
             var postsQuery = _context.Posts.Where(p => p.Medium.Contains(searchMedium)).Include(p => p.Creator).Include(p => p.Likers).ToList(); 
             posts = postsQuery;
         }

        return View(posts);     
    }

//----------------------------add post

   [HttpGet("posts/new")]
   public IActionResult AddPost()
   {
     if (!IsUserLoggedIn()) return RedirectToIndex();
     return View();
   }

   [HttpPost]
    public IActionResult CreatePost(Post NewPost)
    {
     
    //var UserInSession = HttpContext.Session.GetInt32("UserId");
    if (ModelState.IsValid)
    {
        _context.Add(NewPost);
        _context.SaveChanges();
       return RedirectToAction("showOne", new { PostId = NewPost.PostId });

    }    
    return View("AddPost");

    }

    [HttpGet("posts/{PostId}")]
    public IActionResult showOne(int PostId)
    {
         if (!IsUserLoggedIn()) return RedirectToIndex();
        Post post = _context.Posts.Include(p => p.Creator).Include(p=>p.Likers).FirstOrDefault(p=>p.PostId == PostId);
        bool like =_context.Likes.Any(l=>l.PostId ==PostId && l.UserId == HttpContext.Session.GetInt32("UserId"));
        var User = HttpContext.Session.GetInt32("UserId");
        ViewBag.UserId = User;
        ViewBag.Like=like;
        return View(post);
    }

//-------------------------------------------update post

    [HttpGet("posts/edit/{PostId}")]
    public IActionResult EditPost(int PostId)
    {
      if (!IsUserLoggedIn()) return RedirectToIndex();
      var PostToUpdate = _context.Posts.FirstOrDefault(p => p.PostId == PostId);
      var User = HttpContext.Session.GetInt32("UserId");
      ViewBag.UserId = User;
      return View(PostToUpdate);
    }



[HttpPost]
    public IActionResult UpdatePost(Post EditedPost)
    {
    
        if (ModelState.IsValid)
        {
            Post oldPost = _context.Posts.FirstOrDefault(p => p.PostId == EditedPost.PostId);
            oldPost.Image = EditedPost.Image;
            oldPost.Title = EditedPost.Title;
            oldPost.Medium = EditedPost.Medium;
            oldPost.IsForSale = EditedPost.IsForSale;
            oldPost.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
            return RedirectToAction("showOne", new {PostId= EditedPost.PostId});
        }
        return RedirectToAction("EditPost");
    }


//-----------------------------------------delete post
    
    [HttpGet("post/delete/{PostId}")]
    public IActionResult DeletePost(int PostId)
    {
      if (!IsUserLoggedIn()) return RedirectToIndex();
       var PostToDelete = _context.Posts.FirstOrDefault(p => p.PostId == PostId);
        if (PostToDelete != null)
        {
            List<Like> relatedLikes = _context.Likes.Where(p => p.PostId == PostId).ToList();
            foreach (Like l in relatedLikes.ToList())
            {

                    _context.Likes.Remove(l);
                    _context.SaveChanges();

            }
            _context.Posts.Remove(PostToDelete);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    return RedirectToAction("Index");
    }

  //------------------------------------------- like Post 
  [HttpPost]
  public IActionResult LikeThePost(Like newLike)
  {
    _context.Likes.Add(newLike);
    _context.SaveChanges();
    return RedirectToAction("showOne", new {PostId = newLike.PostId});
  }

  //----------------------------------------- unlike Post 
   [HttpPost]
  public IActionResult UnLikeThePost(Like unliked)
  {
    int PostId = unliked.PostId;
    var LikeToDelete = _context.Likes.FirstOrDefault(l=>l.PostId == PostId && l.UserId == unliked.UserId);
    _context.Likes.Remove(LikeToDelete);
    _context.SaveChanges();
    return RedirectToAction("showOne", new {PostId =PostId });
  }
    //---------------------------------IsUserLoggedIn method
    private bool IsUserLoggedIn()
        {
            return HttpContext.Session.GetInt32("UserId") != null;
        }

    private IActionResult RedirectToIndex()
        {
            ModelState.AddModelError("LoginPassword", "You should connect!");
            return RedirectToAction("Index", "Home");
        }
}