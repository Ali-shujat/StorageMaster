using StorageMaster.Model.Vehicles;

namespace StorageMaster.Model.Storages
{
    class Warehouse:Storage
    {
        private const int capacity = 10;
        private const int garageSlot = 10;
        private static readonly Vehicle[] DefaultVehicles =
        {
            new Semi(),new Semi(),new Semi()
        };
        public Warehouse(string name) : base(name, capacity, garageSlot, DefaultVehicles)
        {


        }
    }
}
