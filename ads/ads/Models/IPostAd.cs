using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ads.Models
{
    public interface IPostAd
    {
        int IpostAd(ad a);
        List<ad> getAllAds();
        List<ad> getAdsOfUser(string s);
        List<ad> searchByTitle(string s);
        ad getad(int id);
        void EditAd(ad a);
        void DeleteAd(int id);
    }
    
}
