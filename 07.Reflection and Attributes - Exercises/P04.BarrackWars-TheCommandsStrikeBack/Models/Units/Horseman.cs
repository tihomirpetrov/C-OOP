﻿namespace P04.BarrackWars_TheCommandsStrikeBack.Models.Units
{
    public class Horseman : Unit
    {
        private const int DefaultHealth = 50;
        private const int DefaultDamage = 10;

        public Horseman()
            : base(DefaultHealth, DefaultDamage)
        {
        }
    }
}