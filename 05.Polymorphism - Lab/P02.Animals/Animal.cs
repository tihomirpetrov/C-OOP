namespace Animals
{
    public class Animal
    {
        protected Animal(string name, string favouriteFood)
        {
            this.Name = name;
            this.FavouriteFood = favouriteFood;
        }
        public string Name { get; protected set; }
        public string FavouriteFood { get; protected set; }


        public virtual string ExplainSelf()
        {
            return $"I'm {this.Name} and my favourite food is {this.FavouriteFood}";
        }
    }
}