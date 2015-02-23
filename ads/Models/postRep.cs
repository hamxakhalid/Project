using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
namespace ads.Models
{
    public class postRep:IPostAd
    {
        public int IpostAd(ad d)
        {
            var cx1 = new Database1Entities8();
            var q=cx1.ads.Select(a => new { a.Id });
            
            cx1.ads.Add(d);
            cx1.SaveChanges();
            int max = 0;
            foreach (var x in q)
            {
                if (x.Id > max)
                {
                    max = x.Id;
                }

            }
            
            return max;

        }
        public List<ad> getAllAds()
        {
            var cx1 = new Database1Entities8();
            return cx1.ads.Select(a => a).ToList();
        }
        public List<ad> getAdsOfUser(string s)
        {
            var cx1 = new Database1Entities8();
            ISignUp o = new userRep();
            int id=o.UserId(s);
            var q=cx1.userAds.Where(a => a.userId == id).Select(a => new{ a.adId});
            List<ad> l=new List<ad>();
            foreach (var x in q)
            {
                l.Add(cx1.ads.Find(x.adId));
            }
            return l;

        }
        public List<ad> searchByTitle(string s)
        {
            var cx1 = new Database1Entities8();
            return cx1.ads.Where(a => a.title.Equals(s)).Select(a => a).ToList();

        }
        public ad getad(int id)
        {
            var cx1 = new Database1Entities8();
           return  cx1.ads.Find(id);

        }
        public void EditAd(ad a)
        {
            var cx1 = new Database1Entities8();
            cx1.Entry(a).State = EntityState.Modified;
            cx1.SaveChanges();
        }
        public void DeleteAd(int id)
        {
            var db = new Database1Entities8();
           ad a= db.ads.Find(id);

           db.ads.Remove(a);
           var q = db.userAds.Where(b => b.adId == id).Select(b => b);
           userAd o = null;
           foreach (var x in q)
           {
               o = x;

           }
           db.userAds.Remove(o);
           db.SaveChanges();

        }

    }
}