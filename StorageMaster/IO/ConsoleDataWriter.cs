using StorageMaster.IO.Contracts;
using System;

namespace StorageMaster.IO
{
    class ConsoleDataWriter : IWriter
    {
        public void WriteLine(object obj)
        {
            Console.WriteLine(obj);
        }
    }
}
