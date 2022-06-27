using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;

namespace Zad3
{
    [ServiceContract]
    public interface IZadanie3
    {
        [OperationContract,
         WebGet(UriTemplate = "index.html"),
         XmlSerializerFormat]
        XmlDocument Index();

        [OperationContract,
         WebGet(UriTemplate = "scripts.js"),
         XmlSerializerFormat]
        Stream Script();

        [OperationContract,
        WebInvoke(UriTemplate = "Dodaj/{a}/{b}")]
        int Dodaj(string a, string b);
    }
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IZadanie3
    {
        public int Dodaj(string a, string b)
        {
            return Int32.Parse(a) + Int32.Parse(b);
        }//http://localhost:49886/Service1.svc/zad3/index.html

        public XmlDocument Index()
        {
            var d = new XmlDocument();
            d.XmlResolver = null;
            d.Load("D:\\180542\\KRS6\\index.xhtml");
            return d;
        }

        public Stream Script()
        {
            return new FileStream("D:\\180542\\KRS6\\scripts.js", FileMode.Open);
        }


    }
}
