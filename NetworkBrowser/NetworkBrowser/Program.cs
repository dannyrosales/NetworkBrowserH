using System;
using System.Linq;

namespace NetworkBrowser
{
    class Program
    {

        static void Main(string[] args)
        {
            NetViewer nv = new NetViewer();
            //nv.GetLocalComputerInfo();

            Console.WriteLine("computer name is {0}", nv.LocalComputerName);
            Console.WriteLine("domain name is {0}", nv.LocalDomainName);

            Console.WriteLine("***");

            foreach (var item in nv.ListOfComputerNames)
            {
                Console.WriteLine(item);
            }

            //Console.WriteLine(nv.GetComputersInfoCollection(nv.LocalDomainName).Name);

            Console.ReadKey();
        }

      
    }
}
