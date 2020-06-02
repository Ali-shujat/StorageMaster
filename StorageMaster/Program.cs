using StorageMaster.Core;
using StorageMaster.IO;
using StorageMaster.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageMaster
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Storage Master");
            IReader reader = new ConsoleDataReader();
            IWriter writer = new ConsoleDataWriter();
            Engine StorageEngine = new Engine(reader, writer);
            StorageEngine.Run();
            Console.ReadLine();
     

        }
    }
}
