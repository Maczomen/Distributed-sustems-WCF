using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace test
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [ServiceContract]
    public interface IZadanie3
    {
        [OperationContract,
         WebGet(UriTemplate = "index.html"),
         XmlSerializerFormat]
        XmlDocument Index();
    }
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IZadanie3
    {
        public XmlDocument Index()
        {
            var d = new XmlDocument();
            d.XmlResolver = null;
            d.Load("D:\\180542\\KRS6\\index.xhtml");
            return d;
        }
        
    }
}
