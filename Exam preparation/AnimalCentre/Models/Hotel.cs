﻿namespace AnimalCentre.Models
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using AnimalCentre.Models.Contracts;
    public class Hotel : IHotel
    {
        private const int Capacity = 10;
        //•	Capacity – int with a constant value of 10 
        private readonly Dictionary<string, IAnimal> animals;

        public Hotel()
        {
            this.animals = new Dictionary<string, IAnimal>();
        }

        public IReadOnlyDictionary<string, IAnimal> Animals
        => this.animals.ToImmutableDictionary();

        //•	Animals – Collection with the animal’s name as the key and the animal itself as the value
        public void Accommodate(IAnimal animal)
        {
            if (animals.Count == Capacity)
            {
                throw new InvalidOperationException("Not enough capacity");
            }

            if (animals.ContainsKey(animal.Name))
            {
                throw new ArgumentException($"Animal {animal.Name} already exist");
            }

            this.animals[animal.Name] = animal;
        }

        public void Adopt(string animalName, string owner)
        {
            if (!animals.ContainsKey(animalName))
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }

            animals[animalName].Owner = owner;
            animals[animalName].IsAdopt = true;

            animals.Remove(animalName);
        }
    }
}