namespace StorageMaster.Models.Storage
{
    using System.Collections.Generic;
    using System.Linq;
    using StorageMaster.Models.Products.Contracts;
    using StorageMaster.Models.Storage.Contracts;
    using StorageMaster.Models.Vehicles;
    using StorageMaster.Models.Vehicles.Contracts;

    public abstract class Storage : IStorage
    {
        private string name;
        private int capacity;
        private int garageSlots;

        public Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.GarageSlots = garageSlots;
            
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int GarageSlots { get; set; }

        public bool IsFull
        {
            get => this.IsFull = false;
            set
            {
                if (this.capacity <= Products.Sum(x => x.Weight))
                {
                    this.IsFull = true;
                }

                this.IsFull = false;
            }
        }

        public IReadOnlyCollection<IVehicle> Garage => throw new System.NotImplementedException();

        public IReadOnlyCollection<IProduct> Products => throw new System.NotImplementedException();

        public Vehicle GetVehicle(int garageSlot)
        {
            throw new System.NotImplementedException();
        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            throw new System.NotImplementedException();
        }

        public int UnloadVehicle(int garageSlot)
        {
            throw new System.NotImplementedException();
        }
    }
}
