using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace URLShortner
{    
    [ServiceContract]
    public interface IUrlShortner
    {
        [OperationContract]
        string GetShortUrl(String orignalUrl);
        [OperationContract]
        string GetOriginalUrl(String shortUrl);        
    }    
}
