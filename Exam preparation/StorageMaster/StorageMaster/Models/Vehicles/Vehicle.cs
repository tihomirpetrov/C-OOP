namespace StorageMaster.Models.Vehicles
{
    using StorageMaster.Models.Products.Contracts;
    using StorageMaster.Models.Vehicles.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Vehicle : IVehicle
    {
        private int capacity;
        private List<IProduct> trunk;
        private bool isFull;
        private bool isEmpty;
        public Vehicle(int capacity)
        {
            this.capacity = capacity;
            this.trunk = new List<IProduct>();
            this.isFull = false;
            this.isEmpty = false;
        }

        public IReadOnlyCollection<IProduct> Trunk
        {
            get => this.trunk;
        }
        //public int Capacity { get; set; }

        public bool IsFull
        {
            get => this.isFull;

            private set
            {
                if (this.capacity <= trunk.Sum(x => x.Weight))
                {
                    this.isFull = true;
                }

                this.isFull = false;
            }
        }

        public bool IsEmpty
        {
            get => this.isEmpty;
            set
            {
                if (trunk.Count == 0)
                {
                    this.isEmpty = true;
                }

                this.isEmpty = false;
            }
        }

        public void LoadProduct(IProduct product)
        {
            if (IsFull)
            {
                throw new InvalidOperationException("Vehicle is full!");
            }

            this.trunk.Add(product);
        }

        public IProduct Unload()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("No products left in vehicle!");
            }

            IProduct lastProduct = trunk[this.trunk.Count - 1];

            this.trunk.RemoveAt(this.trunk.Count - 1);

            return lastProduct;            
        }
    }
}