using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageMaster.IO.Contracts
{
    public interface IWriter
    {
        void WriteLine(object obj);
    }
}
