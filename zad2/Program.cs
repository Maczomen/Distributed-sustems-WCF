using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using KSR_WCF1;
using System.ServiceModel.Description;
using System.Runtime.Serialization;

[ServiceContract]
public interface IZadanie2
{
    [OperationContract]
    string Test(string arg);
}

public class Zadanie2: IZadanie2
{
    public string Test(string arg)
    {
        return $"Testowany: {arg}";
    }
}


[DataContract]
public class Wyjatek7
{
    [DataMember]
    public string opis { get; set; }
    [DataMember]
    public string a { get; set; }
    [DataMember]
    public int b { get; set; }
}

[ServiceContract]
public interface IZadanie7
{
    [OperationContract]
    [FaultContract(typeof(Wyjatek7))]
    void RzucWyjatek7(string a, int b);
}

public class Zadanie7 : IZadanie7
{
    public void RzucWyjatek7(string a, int b)
    {
        var exept = new FaultException<Wyjatek7>(new Wyjatek7(),
            new FaultReason($"Zad 67 dziala {a} {b}"));
        throw exept;
    }
}


namespace zad2
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new ServiceHost(typeof(Zadanie2));
            host.AddServiceEndpoint(typeof(IZadanie2),
                new NetNamedPipeBinding(),
                "net.pipe://localhost/ksr-wcf1-zad2");

            var b = host.Description.Behaviors.Find<ServiceMetadataBehavior>();
            if (b == null) b = new ServiceMetadataBehavior();
            host.Description.Behaviors.Add(b);

            host.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName,
                MetadataExchangeBindings.CreateMexNamedPipeBinding(),
                "net.pipe://localhost/metadane");

            host.AddServiceEndpoint(typeof(IZadanie2),
                new NetTcpBinding(),
                "net.tcp://127.0.0.1:55765");

            host.Open();


            var host2 = new ServiceHost(typeof(Zadanie7));
            host2.AddServiceEndpoint(typeof(IZadanie7),
                new NetNamedPipeBinding(),
                "net.pipe://localhost/ksr-wcf1-zad7");

            var c = host2.Description.Behaviors.Find<ServiceMetadataBehavior>();
            if (c == null) c = new ServiceMetadataBehavior();
            host2.Description.Behaviors.Add(c);

            host2.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName,
                MetadataExchangeBindings.CreateMexNamedPipeBinding(),
                "net.pipe://localhost/metadane2");

            host2.Open();

            Console.ReadKey();
            host2.Close();
            host.Close();
        }
    }
}
