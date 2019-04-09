namespace StorageMaster.Models.Storage.Contracts
{
    using StorageMaster.Models.Products.Contracts;
    using StorageMaster.Models.Vehicles;
    using StorageMaster.Models.Vehicles.Contracts;
    using System.Collections.Generic;
    public interface IStorage
    {
        string Name { get; }

        int Capacity { get; }

        int GarageSlots { get; }

        bool IsFull { get; }

        IReadOnlyCollection<IVehicle> Garage { get; }

        IReadOnlyCollection<IProduct> Products { get; }

        Vehicle GetVehicle(int garageSlot);

        int SendVehicleTo(int garageSlot, Storage deliveryLocation);

        int UnloadVehicle(int garageSlot);
    }
}