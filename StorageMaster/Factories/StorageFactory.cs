using StorageMaster.Model.Storages;
using System;

namespace StorageMaster.Factories
{
    class StorageFactory
    {
        public Storage CreateStorage(string type, string name)
        {
            switch (type)
            {
                case "AutomatedWarehouse":
                    return new AutomatedWarehouse(name);

                case "DistributionCenter":
                    return new DistributionCenter(name);

                case "Warehouse":
                    return new Warehouse(name);

                default: throw new InvalidOperationException("Invalid Storage Type");
            }
        }


        //public Storage CreateStorage(string type, string name)
        //{
        //    var storageType = Assembly
        //        .GetCallingAssembly()
        //        .GetTypes()
        //        .Where(x => !x.IsAbstract && x.Name == type)
        //        .FirstOrDefault();

        //    if (storageType == null)
        //    {
        //        throw new InvalidOperationException("Invalid Storage type!");

        //    }
        //    Storage storage = null;

        //    try
        //    {
        //        storage = (Storage)Activator.CreateInstance(storageType, name);
        //    }
        //    catch (TargetInvocationException tie)
        //    {
        //        throw new InvalidOperationException(tie.InnerException.Message);
        //    }
        //    return storage;
        //}
    }
}
