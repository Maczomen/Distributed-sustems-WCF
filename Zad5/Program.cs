using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Zad5
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
    class Program
    {
        static void Main(string[] args)
        {
            var f = new ChannelFactory<IZadanie3>(new WebHttpBinding(),
                new EndpointAddress("http://localhost:49886/Service1.svc/zad3"));
            f.Endpoint.Behaviors.Add(new WebHttpBehavior());
            var c = f.CreateChannel();
            Console.WriteLine(c.Dodaj("7","10"));
            ((IDisposable)c).Dispose();
            Console.ReadKey();
        }
    }
}
