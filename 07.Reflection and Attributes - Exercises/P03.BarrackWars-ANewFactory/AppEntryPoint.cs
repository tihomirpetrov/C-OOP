﻿namespace P03.BarrackWars_ANewFactory
{
    using Contracts;
    using Core;
    using Core.Factories;
    using Data;
    public class AppEntryPoint
    {
        public static void Main()
        {
            IRepository repository = new UnitRepository();
            IUnitFactory unitFactory = new UnitFactory();
            IRunnable engine = new Engine(repository, unitFactory);
            engine.Run();
        }
    }
}