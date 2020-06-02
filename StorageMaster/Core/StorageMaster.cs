using StorageMaster.Factories;
using StorageMaster.Model.Products;
using StorageMaster.Model.Storages;
using StorageMaster.Model.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Core
{
    public class StorageMaster
    {
        private readonly List<Product> productPool;
        private readonly ProductFactory productFactory;
        private readonly List<Storage> storageRegistry;
        private readonly StorageFactory storageFactory;
        private Vehicle vehicle;

        public StorageMaster()
        {
            this.productFactory = new ProductFactory();
            this.productPool = new List<Product>();
            this.storageRegistry = new List<Storage>();
            this.storageFactory = new StorageFactory();
        }

        public string AddProduct(string type, double price)
        {
            var product = this.productFactory.CreateProduct(type, price);
            this.productPool.Add(product);
            return $"Added {type} to pool";
        }

        public string RegisterStorage(string type, string name)
        {
            var storage = this.storageFactory.CreateStorage(type, name);
            this.storageRegistry.Add(storage);
            return $"Registered  {name}";
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            var storage = this.storageRegistry.FirstOrDefault(x => x.Name == storageName);
            this.vehicle = storage.GetVehicle(garageSlot);
            return $"Selected {this.vehicle.GetType().Name}";
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            var loadedProductsCount = 0;
            foreach (var item in productNames)
            {
                //check if vehicle is full
                if (this.vehicle.IsFull)
                {
                    break;
                }
                var pName = this.productPool.Any(x => x.GetType().Name == item);
                //if pName == null ----> Exception
                if (!pName)

                {
                    throw new InvalidOperationException($"{item} is out of stock");
                }
                var lastProduct = productPool.Last(x => x.GetType().Name == item);
                this.productPool.Remove(lastProduct);
                this.vehicle.LoadProduct(lastProduct);
                loadedProductsCount++;
            }
            return $"{loadedProductsCount} / {productNames.Count()} prodcuts into {vehicle.GetType().Name} ";
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            var sourceStorage = this.storageRegistry.FirstOrDefault(x => x.Name == sourceName);
            var destinationStorage = this.storageRegistry.FirstOrDefault(x => x.Name == destinationName);
            if (!this.storageRegistry.Any(x => x.Name == sourceName))
            {
                throw new InvalidOperationException("Invalid source storage");
            }
            if (!this.storageRegistry.Any(x => x.Name == destinationName))
            {
                throw new InvalidOperationException("Invalid destination storage");
            }
            this.vehicle = sourceStorage.GetVehicle(sourceGarageSlot);

            var destinationGarageSlot = sourceStorage.SendVehicleTo(sourceGarageSlot, destinationStorage);
            return $"{this.vehicle.GetType().Name} to {destinationStorage.Name} slot {destinationGarageSlot} ";
        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            var destinationStorage = this.storageRegistry.FirstOrDefault(x => x.Name == storageName);
            this.vehicle = destinationStorage.GetVehicle(garageSlot);
            var unloadedProductsCount = destinationStorage.UnloadVehicle(garageSlot);
            var totalProducts = this.vehicle.Trunk.Count();
            return $" Unloaded  {unloadedProductsCount} / {totalProducts} products at {destinationStorage.Name}";
        }

        public string GetStorageStatus(string storageName)
        {
            var storage = this.storageRegistry.FirstOrDefault(x => x.Name == storageName);
            var stockInfo = storage.Products
                .GroupBy(p => p.GetType().Name)
                .Select(g => new
                { Name = g.Key, Count = g.Count() })
                .OrderByDescending(p => p.Count)
                .ThenBy(p => p.Name)
                .Select(p => $"{p.Name} ({p.Count})")
                .ToArray();
            var productsCapacity = storage.Products.Sum(p => p.Weight);
            var stockFormat = string.Format("Stock ({0}/{1}): [{2}]", productsCapacity, storage.Capacity, string.Join(", ", stockInfo));
            var garage = storage.Garage.ToArray();
            var vehicleNames = garage.Select(vehicle => vehicle?.GetType().Name ?? "empty").ToArray();
            var garageFormat = string.Format("Garage: [{0}]", string.Join("|", vehicleNames));
            return stockFormat + Environment.NewLine + garageFormat;

        }

        public string GetSummary()
        {
            var allStorages = this.storageRegistry.OrderByDescending(x => x.Products.Sum(z => z.Price));
            var stringbuilder = new StringBuilder();
            foreach (var storage in allStorages)
            {
                stringbuilder.Append($"{storage.Name}:");
                stringbuilder.Append($"Storage worth:${storage.Products.Sum(x => x.Price):F2}");
            }
            return stringbuilder.ToString();
        }
    }

}

