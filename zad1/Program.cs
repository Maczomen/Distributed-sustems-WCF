using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using KSR_WCF1;


namespace zad1
{
    class Program
    {
        static void Main(string[] args)
        {
            var fact = new ChannelFactory<IZadanie1>(
                new NetNamedPipeBinding(),
                new EndpointAddress("net.pipe://localhost/ksr-wcf1-test"));

            var client = fact.CreateChannel();
            Console.WriteLine(client.Test("dzialajacy test zad1"));

            var client2 = new ServiceReference1.Zadanie2Client();
            Console.WriteLine("dzialajacy test zad3");

            try
            {
                client.RzucWyjatek(true);
            }
            catch (FaultException<Wyjatek> e)
            {
                Console.WriteLine(client.OtoMagia(e.Detail.magia));
            }

            try
            {
                client.RzucWyjatek(true);
            }
            catch (FaultException<Wyjatek> e)
            {
                Console.WriteLine(client.OtoMagia(e.Detail.magia));
            }

            var client3 = new ServiceReference2.Zadanie7Client();

            try
            {
                client3.RzucWyjatek7("wyjatek", 7);
            }
            catch (FaultException<ServiceReference2.Wyjatek7> e)
            {
                Console.WriteLine(e);
            }

            Console.ReadKey();
            ((IDisposable)client2).Dispose();
            ((IDisposable)client).Dispose();
            fact.Close();
        }
    }
}
