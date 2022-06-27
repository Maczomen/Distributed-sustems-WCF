using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KSR_WCF2;
using System.ServiceModel;


namespace Zad3_4
{
    public class Zadanie3: IZadanie3
    {
        public void TestujZwrotny()
        {
            var zwr = OperationContext.Current.GetCallbackChannel<IZadanie3Zwrotny>();
            for (int i=0;i <= 30; i++)
            {
                zwr.WolanieZwrotne(i, i * i * i - i * i);
            }

        }
    }

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class Zadanie4 : IZadanie4
    {
        public int counter;
        public int Dodaj(int v)
        {
            counter = counter + v;
            return counter;
        }

        public void Ustaw(int v)
        {
            counter = v;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var host = new ServiceHost(typeof(Zadanie3));
            host.AddServiceEndpoint(typeof(IZadanie3),
                new NetNamedPipeBinding(),
                "net.pipe://localhost/ksr-wcf2-zad3");
            var host2 = new ServiceHost(typeof(Zadanie4));
            host2.AddServiceEndpoint(typeof(IZadanie4),
                new NetNamedPipeBinding(),
                "net.pipe://localhost/ksr-wcf2-zad4");

            host.Open();
            host2.Open();
            Console.ReadKey();
            host2.Close();
            host.Close();

        }
    }
}
