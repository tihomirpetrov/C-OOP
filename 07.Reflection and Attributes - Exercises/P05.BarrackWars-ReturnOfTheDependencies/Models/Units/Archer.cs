﻿namespace P05.BarrackWars_ReturnOfTheDependencies.Models.Units
{
    public class Archer : Unit
    {
        private const int DefaultHealth = 25;
        private const int DefaultDamage = 7;

        public Archer() 
            : base(DefaultHealth, DefaultDamage)
        {
        }
    }
}