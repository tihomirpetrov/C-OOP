namespace SoftUniRestaurant.Models.Tables
{
    public class OutsideTable : Table
    {
        public OutsideTable(int tableNumber, int capacity, decimal pricePerPerson) 
            : base(tableNumber, capacity, pricePerPerson)
        {
        }
    }
}