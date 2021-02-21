using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Net;
using URLShortner.DB;

namespace URLShortner
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class UrlShortner : IUrlShortner
    {
        public string GetShortUrl(String orignalUrl)
        {
            if(checkUrl(orignalUrl))
            {
                string shortUrl = "";
                UrlService urlService = new UrlService();
                shortUrl = urlService.CheckUrl(orignalUrl);                
                if (shortUrl == "")
                {
                    shortUrl = Guid.NewGuid().ToString().Substring(0, 8).ToLower();
                    urlService.SaveUrl(new Model.ShortUrl() { ShortKey = shortUrl, Url = orignalUrl, DateCreated = DateTime.Now });
                }                
                return shortUrl;
            }
            else
            {
                return "Enter valid URL...!!!";
            }            
        }
        public String GetOriginalUrl(String shortUrl)
        {
            string orignalUrl = "";
            UrlService urlService = new UrlService();
            orignalUrl = urlService.GetUrl(shortUrl);                                   
            Console.WriteLine("Original : " + orignalUrl);
            
            return orignalUrl;
        }
        public bool checkUrl(String orignalUrl)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(orignalUrl) as HttpWebRequest;
                request.Method = "HEAD";
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;                
                return (response.StatusCode == HttpStatusCode.OK);
            }
            catch
            {                
                return false;
            }
        }
    }
}
