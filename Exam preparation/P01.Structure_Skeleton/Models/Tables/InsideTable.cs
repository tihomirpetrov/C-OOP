namespace SoftUniRestaurant.Models.Tables
{
    using SoftUniRestaurant.Models.Tables.Contracts;
    public class InsideTable : Table
    {
        private const decimal PricePerPersonInsideTable = 2.50M;

        public InsideTable(int tableNumber, int capacity)
            : base(tableNumber, capacity, PricePerPersonInsideTable)
        {
        }
    }
}