namespace StorageMaster.Models.Storage
{
    using System.Collections.Generic;
    using StorageMaster.Models.Vehicles;
    public class DistributionCenter : Storage
    {
        public DistributionCenter(string name, IEnumerable<Vehicle> vehicles) 
            : base(name, 2, 5, vehicles)
        {
        }
    }
}