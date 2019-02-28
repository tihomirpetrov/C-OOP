﻿namespace P02.CarsSalesman
{
    using System.Text;
    public class Engine
    {
        private const string offset = "  ";
        private const string defaultEfficiencyValue = "n/a";

        private string model;
        private int power;
        private int displacement;
        private string efficiency;

        public Engine(string model, int power) : this(model, power, -1, defaultEfficiencyValue)
        {
        }

        public Engine(string model, int power, int displacement) : this(model, power, displacement, defaultEfficiencyValue)
        {
        }

        public Engine(string model, int power, string efficiency) : this(model, power, -1, efficiency)
        {
        }

        public Engine(string model, int power, int displacement, string efficiency)
        {
            this.Model = model;
            this.power = power;
            this.displacement = displacement;
            this.efficiency = efficiency;
        }

        public string Model { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}{1}:\n", offset, this.Model);
            sb.AppendFormat("{0}{0}Power: {1}\n", offset, this.power);
            sb.AppendFormat("{0}{0}Displacement: {1}\n", offset, this.displacement == -1 ? defaultEfficiencyValue : this.displacement.ToString());
            sb.AppendFormat("{0}{0}Efficiency: {1}\n", offset, this.efficiency);

            return sb.ToString();
        }
    }
}