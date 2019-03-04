namespace P05.PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.flourType = flourType;
            this.bakingTechnique = bakingTechnique;
            this.weight = weight;
        }

        public double CalculateCalories()
        {
            return 0;
        }
    }
}