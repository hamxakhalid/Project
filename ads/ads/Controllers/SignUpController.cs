using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ads.Models;
using System.Data.EntityModel;

namespace ads.Controllers
{
    public class SignUpController : Controller
    {
        //
        // GET: /SignUp/

        ISignUp obj;
        IPostAd obj2;
        IUserAds obj3;
        
        public SignUpController(IPostAd post, ISignUp sign,IUserAds o)
        {
            obj2 = post;
            obj = sign;
            obj3 = o;
        }
        
        public ActionResult SignUp()
        {
            return View();
        }
        public ActionResult Signin()
        {

            return View();
        }
        public ActionResult loginUser(User user)
        {
            
                bool i = obj.loginUser(user);

                if (i)
                {
                    Session["name"] = user.UserName;
                    Session["userId"] = obj.UserId(user.UserName);
                    //return View("session");
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Signin", "SignUp");
                }

            
            
        }
        public ActionResult Save(User u)
        {
            
                obj.IsignUp(u);
                return RedirectToAction("Index", "Home");
            
            
        }

        public JsonResult CheckUserName()
        {

            string userName = Request["UserName"];
            bool i = obj.ICheckUserName(userName);
            //check from database
            
            // List<Student> list = new List<Student>();
            if (i)
            {
                return this.Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return this.Json(false, JsonRequestBehavior.AllowGet);
            }

        }
    }
}
