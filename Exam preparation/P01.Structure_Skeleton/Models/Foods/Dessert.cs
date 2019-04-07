﻿namespace SoftUniRestaurant.Models.Foods
{
    using SoftUniRestaurant.Models.Foods.Contracts;
    public class Dessert : Food, IFood
    {
        public const int servingSizeInitial = 200;
        public Dessert(string name, decimal price, int servingSize = servingSizeInitial)
            : base(name, price, servingSize)
        {            
        }
    }
}