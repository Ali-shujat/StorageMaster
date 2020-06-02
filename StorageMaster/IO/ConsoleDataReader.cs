using StorageMaster.IO.Contracts;
using System;

namespace StorageMaster.IO
{
    class ConsoleDataReader : IReader

    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
