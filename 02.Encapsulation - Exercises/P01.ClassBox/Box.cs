namespace P01.ClassBox
{
    using System.Text;
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.length = length;
            this.width = width;
            this.height = height;
        }                

        public double CalculateSurfaceArea()
        {
            return (2 * this.length * this.width) + (2 * this.width * this.height) + (2 * this.length * this.height);
        }

        public double CalculateLateralSurfaceArea()
        {
            return (2 * this.length * this.height) + (2 * this.width * this.height);
        }

        public double CalculateVolume()
        {
            return this.length * this.width * this.height;
        }
    }
}