using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ads.Models
{
    public class UserAdsResp:IUserAds
    {
        public void saveUserAdData(int adId, int UId)
        {
            var cx = new Database1Entities8();
            userAd o = new userAd();
            o.adId = adId;
            o.userId = UId;
            cx.userAds.Add(o);
            cx.SaveChanges();

        }
    }
}