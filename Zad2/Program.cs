using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Discovery;
using System.Text;
using System.Threading.Tasks;

namespace Zad2
{
    [ServiceContract]
    public interface IZadanie1
    {
        [OperationContract]
        string ScalNapisy(string a, string b);
    }
    class Program
    {
        static void Main(string[] args)
        {
            DiscoveryClient discoveryClient = new DiscoveryClient(new UdpDiscoveryEndpoint("soap.udp://localhost:30703"));//10.255.255.255:54321
            System.Collections.ObjectModel.Collection<EndpointDiscoveryMetadata> lst = discoveryClient.Find(new FindCriteria(typeof(IZadanie1))).Endpoints;
            discoveryClient.Close();
            if (lst.Count > 0)
            {
                var addr = lst[0].Address; // łączymy się z pierwszym znalezionym
                var proxy = ChannelFactory<IZadanie1>.CreateChannel(new NetNamedPipeBinding(),
                 addr);

                Console.WriteLine(proxy.ScalNapisy("Udalo ", "sie!"));              
                ((IDisposable)proxy).Dispose();
            }

            Console.ReadKey();
        }
    }
}
