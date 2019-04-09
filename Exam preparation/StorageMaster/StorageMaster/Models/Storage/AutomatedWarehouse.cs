namespace StorageMaster.Models.Storage
{
    using System.Collections.Generic;
    using StorageMaster.Models.Vehicles;
    public class AutomatedWarehouse : Storage
    {
        public AutomatedWarehouse(string name, IEnumerable<Vehicle> vehicles)
            : base(name, 1, 2, vehicles)
        {
        }
    }
}