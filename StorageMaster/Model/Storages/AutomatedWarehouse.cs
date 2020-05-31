using StorageMaster.Model.Vehicles;

namespace StorageMaster.Model.Storages
{
    public class AutomatedWarehouse : Storage
    {
        private const int capacity = 1;
        private const int garageSlot=2;
        private static readonly Vehicle[] DefaultVehicles =
        {
            new Truck()
        };
        public AutomatedWarehouse(string name) : base(name, capacity, garageSlot, DefaultVehicles) 
        { 
        
        
        }

    }
}
