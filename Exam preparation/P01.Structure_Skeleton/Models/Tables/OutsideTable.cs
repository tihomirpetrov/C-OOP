namespace SoftUniRestaurant.Models.Tables
{
    using SoftUniRestaurant.Models.Tables.Contracts;
    public class OutsideTable : Table, ITable
    {
        private const decimal PricePerPersonOutsideTable = 3.50M;

        public OutsideTable(int tableNumber, int capacity, decimal pricePerPerson = PricePerPersonOutsideTable) 
            : base(tableNumber, capacity, pricePerPerson)
        {
        }
    }
}