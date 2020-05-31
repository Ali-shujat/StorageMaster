using StorageMaster.Factories;
using StorageMaster.Model.Products;
using StorageMaster.Model.Storages;
using StorageMaster.Model.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageMaster.Core
{
    class StorageMaster
    {
        private readonly List<Product> productPool;
        private readonly ProductFactory productFactory;
        private readonly StorageFactory _StorageFactory;
        private readonly List<Storage> storageRegistry;
        private Vehicle[] garageSlot;
        private Vehicle vehicle;

        public StorageMaster(ProductFactory productFactory,StorageFactory storageFactory)
        {
            this._StorageFactory = storageFactory; 
            this.productFactory = productFactory;
            this.productPool = new List<Product>();
            this.storageRegistry = new List<Storage>();
        }
        public string AddProduct(string type, double price)
        {
            var product = this.productFactory.CreateProduct(type, price);
            this.productPool.Add(product);
            return $"Added {type} to pool";
        }

        public string RegisterStorage(string type, string name)
        {
            var storage = this._StorageFactory.CreateStorage(type, name);

            return $"Selected{name}";
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            var storage = this.storageRegistry.FirstOrDefault(x => x.Name == storageName);

            this.vehicle = storage.GetVehicle(garageSlot);
            return $"Selected {this.vehicle.GetType().Name}";
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            var listProduct = this.productPool.Any().GetType() == productNames;
           // var product = this.productPool.GetType().se( productNames);
            foreach (var p in productNames)
                if(!listProduct)
                {
                    throw new InvalidOperationException($"{p} is out of stock!");
                }
                    else
                {
                   // vehicle.LoadProduct();
                }
            throw new NotImplementedException();
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            var sourceStorage = this.storageRegistry.FirstOrDefault(x => x.Name == sourceName);
            var destinationStorage = this.storageRegistry.FirstOrDefault(x => x.Name == destinationName);

            {

            }
            throw new NotImplementedException();
        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            var storage = this.storageRegistry.FirstOrDefault(x => x.Name == storageName);
            this.vehicle = storage.GetVehicle(garageSlot);
            var productsInVehicle = vehicle.Trunk.Count();
            var unloadedProductsCount = storage.Capacity - productsInVehicle;
             storage.UnloadVehicle(garageSlot);
            return $" Unloaded { unloadedProductsCount}/{ productsInVehicle} products at { storageName}";
            
        }

        public string GetStorageStatus(string storageName)
        {
            throw new NotImplementedException();
        }

        public string GetSummary()
        {
            throw new NotImplementedException();
        }

    }
}
