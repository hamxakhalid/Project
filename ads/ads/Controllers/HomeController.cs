using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ads.Models;
using System.Data.EntityModel;
namespace ads.Controllers
{
    public class HomeController : Controller
    {
        //
        ISignUp obj;
        IPostAd obj2;
        IUserAds obj3;
        // GET: /Home/
        public HomeController(IPostAd post, ISignUp sign,IUserAds o)
        {
            obj2 = post;
            obj = sign;
            obj3 = o;

        }
        public ActionResult Index()
        {
            if (Session["name"] == null)
            {
                return View("Index",obj2.getAllAds());
            }
            else
            {
                return View("AfterLoginIndex",obj2.getAdsOfUser(Session["name"].ToString()));
            }
        }
       
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Logout()
        {
            
            Session["name"] = null;
            Session["userId"] = null;
            return View("Index", obj2.getAllAds());

        }
        public ActionResult editAd()
        {
            return View();
        }
        public ActionResult deleteAd()
        {
            return View();
        }
        public ActionResult back()
        {
            return View("AfterLoginIndex", obj2.getAdsOfUser(Session["name"].ToString()));

        }
        public ActionResult Edit(int id)
        {
            return View(obj2.getad(id));
        }
        [HttpPost]
        public ActionResult Edit(ad newVal)
        {
            obj2.EditAd(newVal);
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Delete(int id)
        {
            return View(obj2.getad(id));
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfrm(int id)
        {
            obj2.DeleteAd(id);
            return RedirectToAction("Index", "Home");
        }

    }
}
