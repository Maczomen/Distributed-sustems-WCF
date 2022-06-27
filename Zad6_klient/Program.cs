using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Zad6_klient
{
    [ServiceContract]
    public interface IZadanie6
    {
        [OperationContract]
        int Dodaj(int a, int b);
    }
    class Program
    {
        static void Main(string[] args)
        {
            var fact = new ChannelFactory<IZadanie6>(
                new NetNamedPipeBinding(),
                new EndpointAddress("net.pipe://localhost/router"));

            var client = fact.CreateChannel();
            // korzystamy z usługi
            Console.WriteLine("wynik={0}", client.Dodaj(1, 2));


            Console.ReadKey();
            ((IDisposable)client).Dispose();
            // fabrykę możemy zwolnić dopiero wtedy, gdy skończymy korzystać z utworzonych
            // przez nią kanałów
            fact.Close();

        }
    }
}
