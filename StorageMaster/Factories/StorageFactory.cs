using StorageMaster.Model.Storages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StorageMaster.Factories
{
    class StorageFactory
    {
        public Storage CreateStorage(string type, string name)
        {
            var storageType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .Where(x => !x.IsAbstract && x.Name == type)
                .FirstOrDefault();

            if (storageType == null)
            {
                throw new InvalidOperationException("Invalid Storage type!");

            }
            Storage storage = null;

            try
            {
                storage = (Storage)Activator.CreateInstance(storageType, name);
            }
            catch (TargetInvocationException tie)
            {
                throw new InvalidOperationException(tie.InnerException.Message);
            }
            return storage;
        }
    }
}
