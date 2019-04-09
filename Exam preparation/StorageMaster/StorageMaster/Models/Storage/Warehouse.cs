namespace StorageMaster.Models.Storage
{
    using System.Collections.Generic;
    using StorageMaster.Models.Vehicles;
    public class Warehouse : Storage
    {
        public Warehouse(string name, IEnumerable<Vehicle> vehicles)
            : base(name, 10, 10, vehicles)
        {
        }
    }
}