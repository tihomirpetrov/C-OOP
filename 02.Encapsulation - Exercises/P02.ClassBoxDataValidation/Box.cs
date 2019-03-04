namespace P02.ClassBoxDataValidation
{
    using System;
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get
            {
                return this.length;
            }
            private set
            {
                this.ValidateParameter(value, nameof(this.Length));
                this.length = value;
            }
        }
        public double Width
        {
            get
            {
                return this.width;
            }
            private set
            {                
                this.ValidateParameter(value, nameof(this.Width));
                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                this.ValidateParameter(value, nameof(this.Height));

                this.height = value;
            }
        }
        private void ValidateParameter(double value, string parameterName)
        {
            if (value < 0)
            {
                throw new ArgumentException($"{parameterName} cannot be zero or negative.");
            }
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