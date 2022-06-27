using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad1
{
    class Program
    {
        public class Handler: ServiceReference2.IZadanie2Callback
        {
            public void Zadanie(string zadanie, int pkt, bool zaliczone)
            {
                Console.WriteLine($"{zadanie} na {pkt}% zaliczone: {zaliczone}");
            }
        }
        static void Main(string[] args)
        {
            var client1 = new ServiceReference1.Zadanie1Client();
            IAsyncResult result = client1.BeginDlugieObliczenia(null, null);

            for (int i = 0; i <= 20; i++)
            {
                client1.Szybciej(i, 3 * i * i - 2 * i);
            }

            result.AsyncWaitHandle.WaitOne();
            Console.WriteLine(client1.EndDlugieObliczenia(result));
            Console.ReadKey();
            ((IDisposable)client1).Dispose();

            var client2 = new ServiceReference2.Zadanie2Client(new System.ServiceModel.InstanceContext(new Handler()));
            client2.PodajZadania();
            Console.ReadKey();
            ((IDisposable)client2).Dispose();
        }
    }
}
