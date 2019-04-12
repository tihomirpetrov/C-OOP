﻿namespace DungeonsAndCodeWizards
{
    using System;
    using System.Linq;

    public class Engine
    {
        private bool isRunning;
        private readonly IReader reader;
        private readonly IWriter writer;

        private DungeonMaster dungeonMaster;
        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            this.dungeonMaster = new DungeonMaster();
        }

        public void Run()
        {
            this.isRunning = true;

            while (this.isRunning)
            {
                string command = this.reader.ReadLine();
                try
                {
                    this.ReadCommand(command);
                }
                catch (ArgumentException e)
                {
                    this.writer.WriteLine("Parameter Error: " + e.Message);
                }
                catch (InvalidOperationException e)
                {
                    this.writer.WriteLine("Invalid Operation: " + e.Message);
                }

                if (this.dungeonMaster.IsGameOver() || this.isRunning == false)
                {
                    this.writer.WriteLine("Final stats:");
                    this.writer.WriteLine(this.dungeonMaster.GetStats());
                    this.isRunning = false;
                }
            }
        }

        private void ReadCommand(string command)
        {
            string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string commandName = commandArgs[0];
            string[] args = commandArgs.Skip(1).ToArray();

            var output = string.Empty;

            switch (command)
            {
                case "JoinParty":
                    output = this.dungeonMaster.JoinParty(args);
                    break;
                case "AddItemToPool":
                    output = this.dungeonMaster.AddItemToPool(args);
                    break;
                case "PickUpItem":
                    output = this.dungeonMaster.PickUpItem(args);
                    break;
                case "UseItem":
                    output = this.dungeonMaster.UseItem(args);
                    break;
                case "GiveCharacterItem":
                    output = this.dungeonMaster.GiveCharacterItem(args);
                    break;
                case "UseItemOn":
                    output = this.dungeonMaster.UseItemOn(args);
                    break;
                case "GetStats":
                    output = this.dungeonMaster.GetStats();
                    break;
                case "Attack":
                    output = this.dungeonMaster.Attack(args);
                    break;
                case "Heal":
                    output = this.dungeonMaster.Heal(args);
                    break;
                case "EndTurn":
                    output = this.dungeonMaster.EndTurn(args);
                    break;
            }
            if (output != string.Empty)
            {
                this.writer.WriteLine(output);
            }
        }
    }
}
