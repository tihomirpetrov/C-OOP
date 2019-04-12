namespace DungeonsAndCodeWizards
{
    using DungeonsAndCodeWizards.Models.Bags;
    using DungeonsAndCodeWizards.Models.Characters;
    using DungeonsAndCodeWizards.Models.Items;
    using System;
    using System.Collections.Generic;

    public class DungeonMaster
    {
        private readonly List<Character> party;

        public DungeonMaster()
        {
            this.party = new List<Character>();
        }
        public string JoinParty(string[] args)
        {
            string faction = args[0];
            string characterType = args[1];
            string name = args[2];

            Character character = null;
            if (characterType != faction)
            {
                throw new ArgumentException($"Invalid faction \"{faction}\"!");
            }
            if (string.IsNullOrEmpty(characterType) || string.IsNullOrWhiteSpace(characterType))
            {
                return $"Invalid character type \"{characterType}\"!";
            }

            return $"{name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];

            Item item = null;


            if (string.IsNullOrEmpty(itemName) || string.IsNullOrWhiteSpace(itemName))
            {
                throw new ArgumentException($"Invalid item \"{itemName}\"!");
            }

            return $"{itemName} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            //string characterName = args[0];
            throw new NotImplementedException();
        }

        public string UseItem(string[] args)
        {
            throw new NotImplementedException();
        }

        public string UseItemOn(string[] args)
        {
            throw new NotImplementedException();
        }

        public string GiveCharacterItem(string[] args)
        {
            throw new NotImplementedException();
        }

        public string GetStats()
        {
            throw new NotImplementedException();
        }

        public string Attack(string[] args)
        {
            throw new NotImplementedException();
        }

        public string Heal(string[] args)
        {
            throw new NotImplementedException();
        }

        public string EndTurn(string[] args)
        {
            throw new NotImplementedException();
        }

        public bool IsGameOver()
        {
            throw new NotImplementedException();
        }
    }
}