namespace P07.InfernoInfinity
{
<<<<<<< HEAD
    using P07.InfernoInfinity.Weapons;
=======
    using P07.InfernoInfinity.Contracts;
    using P07.InfernoInfinity.Models.Enums;
>>>>>>> 3a5de72a12a84b31379dbb5ea8b26ff73e1993df
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        static List<IWeapon> weapons = new List<IWeapon>();

        static void Main()
        {
            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputTokens = input.Split(';', StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    switch (inputTokens[0])
                    {
                        case "Create":
                            IWeapon weapon = CreateWeapon(inputTokens);
                            weapons.Add(weapon);
                            break;
                        case "Add":
                            AddSocket(inputTokens);
                            break;
                        case "Remove":
                            RemoveSocket(inputTokens);
                            break;
                        case "Print":
                            PrintWeapon(inputTokens);
                            break;
                        default:
                            throw new ArgumentException($"Invalid Command: {inputTokens[0]}!");
                    }
                }
                catch (Exception)
                {

                }
            }
        }

        private static void PrintWeapon(string[] inputTokens)
        {
            string weaponName = inputTokens[1];

            IWeapon weapon = weapons.First(w => w.Name == weaponName);

            foreach (IGem gem in weapon.Gems.Where(g => g != null))
            {
                weapon.Modify(gem);
            }

            Console.WriteLine(weapon);
        }

        private static void RemoveSocket(string[] inputTokens)
        {
            string weaponName = inputTokens[1];
            int socketIndex = int.Parse(inputTokens[2]);

            IWeapon weapon = weapons.First(w => w.Name == weaponName);

            if (socketIndex >= 0 && socketIndex < weapon.Gems.Length)
            {
                IGem gem = weapon.Gems[socketIndex];

                if (gem != null)
                {
                    weapon.DegradeWeapon(gem);
                    weapon.Gems[socketIndex] = null;
                }
            }
        }

        private static void AddSocket(string[] inputTokens)
        {
            string weaponName = inputTokens[1];
            IWeapon weapon = weapons.First(w => w.Name == weaponName);
            int socketIndex = int.Parse(inputTokens[2]);
            string[] gemTokens = inputTokens[3].Split(' ', StringSplitOptions.RemoveEmptyEntries);

            GemQuality quality = Enum.Parse<GemQuality>(gemTokens[0]);

            Type gemType = Type.GetType(gemTokens[1]);

            if (gemType == null)
            {
                throw new ArgumentException("Invalid Gem Type!");
            }

            if (!typeof(IGem).IsAssignableFrom(gemType))
            {
                throw new ArgumentException("Invalid Gem!");
            }

            IGem gem = (IGem)Activator.CreateInstance(gemType, new object[] { quality });

            if (socketIndex >= 0 && socketIndex < weapon.Gems.Length)
            {
                weapon.Gems[socketIndex] = gem;
            }
        }

        private static IWeapon CreateWeapon(string[] inputTokens)
        {
            string[] weaponTokens = inputTokens[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);

            WeaponRarity rarity = Enum.Parse<WeaponRarity>(weaponTokens[0]);

            Type weaponType = Type.GetType(weaponTokens[1]);

            if (weaponType == null)
            {
                throw new ArgumentException("Invalid Weapon Type!");
            }

            if (!typeof(IWeapon).IsAssignableFrom(weaponType))
            {
                throw new ArgumentException("Invalid Weapon!");
            }

            IWeapon weapon = (IWeapon)Activator.CreateInstance(weaponType, new object[] { rarity, inputTokens[2] });

            return weapon;
        }
    }
}