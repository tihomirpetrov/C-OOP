namespace P03.WildFarm.Models.Foods
{
    public abstract class Food
    {
        protected Food(int quantity)
        {
            this.Qunatity = quantity;
        }

        public int Qunatity { get; set; }
    }
}