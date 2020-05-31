using StorageMaster.Model.Vehicles;


namespace StorageMaster.Model.Storages
{
    public class DistributionCenter : Storage
    {
        private const int capacity = 2;
        private const int garageSlot = 5;
        private static readonly Vehicle[] DefaultVehicles =
        {
            new Van(),new Van(),new Van()
        };

        public DistributionCenter(string name) : base(name, capacity, capacity, DefaultVehicles)
        {

        }
    }
}
