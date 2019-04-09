namespace StorageMaster.Models.Vehicles.Contracts
{
    using StorageMaster.Models.Products.Contracts;
    using System.Collections.Generic;

    public interface IVehicle
    {
        //int Capacity { get; }
        bool IsFull { get; }
        bool IsEmpty { get; }

        IReadOnlyCollection<IProduct> Trunk { get; }

        void LoadProduct(IProduct product);

        IProduct Unload();
    }
}