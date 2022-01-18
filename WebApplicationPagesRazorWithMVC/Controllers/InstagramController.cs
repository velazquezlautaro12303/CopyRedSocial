using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationPagesRazorWithMVC.Models;

namespace WebApplicationPagesRazorWithMVC.Controllers
{
    public class InstagramController : Controller
    {
        private InstagramEntities db = new InstagramEntities();
        private int idTweet = 11;

        // GET: Instagram
        public ActionResult Index()
        {
            HttpCookie cookie = Request.Cookies["miCookie"];
            if (cookie != null)
            {
                ViewBag.CokieNameUser = cookie["Name"];
                var tweet = db.Tweet.Find(idTweet);
                var user = db.tUser.Find(tweet.UserID);

                var pathPhotos = new List<String>();
                foreach (var photo in tweet.Photo)
                {
                    pathPhotos.Add(photo.path);
                }

                ViewBag.NameUser = user.NameUser;
                ViewBag.DateTime = tweet.Date;
                ViewBag.Description = tweet.Description;
                ViewBag.CountShare = tweet.Share.Count;
                ViewBag.CountComment = tweet.Comment.Count;
                ViewBag.CountLikes = tweet.tLike.Count;
                ViewBag.MainPhoto = pathPhotos;
                return View(db.Tweet.ToList());
            }
            else 
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(tUser user)
        {
            if (ModelState.IsValid)
            {
                if (db.tUser.Where(u => u.NameUser == user.NameUser).Any())
                {
                    HttpCookie miCookie = new HttpCookie("miCookie");
                    miCookie["NameUser"] = user.NameUser;
                    miCookie.Expires = DateTime.Now.AddDays(30);
                    Response.Cookies.Add(miCookie);
                    return RedirectToAction("Index");
                }
            }

            return View();
        }
    }
}