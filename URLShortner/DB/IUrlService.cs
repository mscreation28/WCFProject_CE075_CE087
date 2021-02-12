using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using URLShortner.Model;

namespace URLShortner.DB
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUrlService" in both code and config file together.
    [ServiceContract]
    public interface IUrlService
    {
        [OperationContract]
        public String GetUrl(String key);
        [OperationContract]
        public void SaveUrl(ShortUrl url);
        [OperationContract]
        public String CheckUrl(String orignalUrl);
    }
}
