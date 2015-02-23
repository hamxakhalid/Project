using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ads.Models;
using System.Data.EntityModel;

namespace ads.Controllers
{
    public class PostAdController : Controller
    {
        //
        // GET: /PostAd/

        IPostAd obj;
        ISignUp obj2;
        IUserAds obj3;
        
        public PostAdController(ISignUp sign, IPostAd post,IUserAds o)
        {
            obj2 = sign;
            obj = post;            
            obj3=o;
        }

        public ActionResult PostAd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveAd(ad a)
        {

                for (int i = 0; i < Request.Files.Count; i++)
                {
                    HttpPostedFileBase file = Request.Files[i];
                    file.SaveAs(Server.MapPath(@"~\images\" + a.Id+file.FileName));
                    a.image = @"\images\" + a.Id + file.FileName;
                }

               int adId=obj.IpostAd(a);
              if (Session["name"] != null)
                {
                    obj3.saveUserAdData(adId, int.Parse(Session["userId"].ToString()));
                }
                return RedirectToAction("Index", "Home");
            


        }
        public JsonResult searchAdByTitle()
        {
            List<ad> l=obj.searchByTitle(Request["Title"]);
           return this.Json(l, JsonRequestBehavior.AllowGet);
        }
    }
}
