using StorageMaster.Model.Vehicles;
using StorageMaster.Model.Products;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorageMaster.Model.Storages
{
    public abstract class Storage
    {

        private List<Product> products;

        private Vehicle[] garage;
        private int garageSlots;
        private string name;
        private int capacity;


        protected Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.GarageSlots = garageSlots;
            this.products = new List<Product>();
            this.garage = new Vehicle[this.GarageSlots];

        }

        public string Name { get; private set; }
        public int Capacity { get; private set; }
        public int GarageSlots { get; private set; }


        public bool IsFull => this.Products.Sum(p => p.weight) >= this.Capacity;

        public IReadOnlyCollection<Vehicle> Garage => this.garage;
        public IReadOnlyCollection<Product> Products => this.products;


        public Vehicle GetVehicle(int garageSlot)
        {

            if (garageSlot >= this.GarageSlots)
            {

                throw new InvalidOperationException("Invalid garage slot!");
            }

            if (this.garage[garageSlot] == null)
            {
                throw new InvalidOperationException("No vehicle in this garage slot!");

            }

            return this.garage[garageSlot];//Needs to be checked if it returns value
        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            var vehicle = this.GetVehicle(garageSlot);

            var hasFreeGarageSlots = deliveryLocation.Garage.Any(x => x == null);

            if (hasFreeGarageSlots == false)
            {
                throw new InvalidOperationException("No room in garage!");

            }
            this.garage[garageSlots] = null;

            var addedSlot = deliveryLocation.AddVehicle(vehicle);

            return addedSlot;

        }

        private int AddVehicle(Vehicle vehicle)
        {
            var emptySlot = Array.IndexOf(this.garage, null);

            this.garage[emptySlot] = vehicle;

            return emptySlot;
        }

        public int UnloadVehicle(int garageSlot)
        {

            if (this.IsFull)
            {

                throw new InvalidOperationException("Storage is full!");
            }
            var vehicle = this.GetVehicle(garageSlot);

            var result = 0;

            while (vehicle.IsEmpty && !this.IsFull)//Need to be tested for !
            {
                var vehicleProduct = vehicle.Unload();

                this.products.Add(vehicleProduct);

                result++;
            }

            return result;
        }
    }
}
