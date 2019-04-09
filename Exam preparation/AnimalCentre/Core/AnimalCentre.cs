namespace AnimalCentre.Core
{
    using global::AnimalCentre.Core.AnimalFactory;
    using global::AnimalCentre.Models;
    using global::AnimalCentre.Models.Contracts;
    using global::AnimalCentre.Models.Procedures;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class AnimalCentre
    {
        private IAnimalFactory animalFactory;
        private readonly IHotel hotel;
        private Dictionary<string, IProcedure> procedureAnimals;
        private Dictionary<string, List<string>> adoptedAnimals;

        public AnimalCentre()
        {
            this.animalFactory = new AnimalFactory.AnimalFactory();
            this.hotel = new Hotel();
            this.procedureAnimals = new Dictionary<string, IProcedure>
            {
                 { "Chip", new Chip()},
                 { "Vaccinate", new Vaccinate()},
                 { "Fitness", new Fitness()},
                 { "Play", new Play()},
                 { "DentalCare", new DentalCare()},
                 { "NailTrim", new NailTrim()},
            };
            this.adoptedAnimals = new Dictionary<string, List<string>>();
        }

        public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            var animal = this.animalFactory.CreateAnimal(type, name, energy, happiness, procedureTime);

            this.hotel.Accommodate(animal);

            return $"Animal {animal.Name} registered successfully";
        }

        public string Chip(string name, int procedureTime)
        {
            this.CheckAnimalExist(name);

            var animal = this.hotel.Animals[name];
            this.procedureAnimals["Chip"].DoService(animal, procedureTime);

            return $"{animal.Name} had chip procedure";
        }

        public string Vaccinate(string name, int procedureTime)
        {
            this.CheckAnimalExist(name);

            var animal = this.hotel.Animals[name];
            this.procedureAnimals["Vaccinate"].DoService(animal, procedureTime);

            return $"{animal.Name} had vaccination procedure";
        }

        public string Fitness(string name, int procedureTime)
        {
            this.CheckAnimalExist(name);

            var animal = this.hotel.Animals[name];
            this.procedureAnimals["Fitness"].DoService(animal, procedureTime);

            return $"{animal.Name} had fitness procedure";
        }

        public string Play(string name, int procedureTime)
        {
            this.CheckAnimalExist(name);

            var animal = this.hotel.Animals[name];
            this.procedureAnimals["Play"].DoService(animal, procedureTime);

            return $"{animal.Name} was playing for {procedureTime} hours";
        }

        public string DentalCare(string name, int procedureTime)
        {
            this.CheckAnimalExist(name);

            var animal = this.hotel.Animals[name];
            this.procedureAnimals["DentalCare"].DoService(animal, procedureTime);

            return $"{animal.Name} had dental care procedure";
        }

        public string NailTrim(string name, int procedureTime)
        {
            this.CheckAnimalExist(name);

            var animal = this.hotel.Animals[name];
            this.procedureAnimals["NailTrim"].DoService(animal, procedureTime);

            return $"{animal.Name} had nail trim procedure";
        }

        public string Adopt(string animalName, string owner)
        {
            this.CheckAnimalExist(animalName);

            IAnimal animal = this.hotel.Animals[animalName];

            this.hotel.Adopt(animalName, owner);

            if (!this.adoptedAnimals.ContainsKey(owner))
            {
                this.adoptedAnimals[owner] = new List<string>();
            }
            this.adoptedAnimals[owner].Add(animalName);

            if (animal.IsChipped)
            {
                return $"{owner} adopted animal with chip";
            }
            else
            {
                return $"{owner} adopted animal without chip";
            }
        }

        public string History(string type)
        {
            return this.procedureAnimals[type].History();
        }


        public string AllAdoptedAnimals()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var adoptedAnimal in this.adoptedAnimals)
            {
                sb.AppendLine($"--Owner: {adoptedAnimal.Key}");
                var animalNames = string.Join(" ", adoptedAnimal.Value.OrderBy(x => x));
                sb.AppendLine($"- Adopted animals: {animalNames}");
            }

            string result = sb.ToString().TrimEnd();
            return result;
        }
        private void CheckAnimalExist(string name)
        {
            if (!this.hotel.Animals.ContainsKey(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }
        }
    }
}