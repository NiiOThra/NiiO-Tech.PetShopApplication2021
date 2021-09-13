using System;
using System.Collections.Generic;
using System.Linq;
using NiiO_Tech.PetShopApplication2021.Core.Models;
using NiiO_Tech.PetShopApplication2021.Domain.IRepositories;

namespace NiiO_Tech.PetShopApplication2021.Infrastructure.Data.Repositories
{
    public class PetRepository : IPetRepository
    {
        private static readonly List<Pet> Pets = new List<Pet>();
        private static int _petId = 1;

        public Pet Add(Pet pet)
        {
            pet.Id = _petId++;
            Pets.Add(pet);
            return pet;
        }

        public List<Pet> FindAllPets()
        {
            return Pets;
        }

        public Pet ReadById(int id)
        {
            return Pets.FirstOrDefault(pet => pet.Id == id);
        }

        public Pet Update(Pet petUpdate)
        {
            var pet = ReadById(petUpdate.Id);
            if (pet == null) return null;
            pet.Name = petUpdate.Name;
            pet.Price = petUpdate.Price;
            return pet;

        }

        public void Delete(int petIdRemove)
        {
            var petFound = ReadById(petIdRemove);
            if (petFound != null)
            {
                Pets.Remove(petFound);
            }
        }
    }
}