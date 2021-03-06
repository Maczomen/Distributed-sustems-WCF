using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Zad6_serwer1
{
    [ServiceContract]
    public interface IZadanie6
    {
        [OperationContract]
        int Dodaj(int a, int b);
    }

    public class Zadanie6 : IZadanie6
    {
        public int Dodaj(int a, int b)
        {
            return a + b + 100;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var host = new ServiceHost(typeof(Zadanie6));
            host.AddServiceEndpoint(typeof(IZadanie6),
                new NetNamedPipeBinding(),
                "net.pipe://localhost/zad6_1");
            host.Open();


            Console.ReadKey();
            host.Close();
        }
    }
}
