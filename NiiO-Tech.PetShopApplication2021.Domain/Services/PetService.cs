using System.Collections.Generic;
using System.Linq;
using NiiO_Tech.PetShopApplication2021.Core.IServices;
using NiiO_Tech.PetShopApplication2021.Core.Models;
using NiiO_Tech.PetShopApplication2021.Domain.IRepositories;

namespace NiiO_Tech.PetShopApplication2021.Domain.Services
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _repo;
        
        public PetService(IPetRepository repo)
        {
            _repo = repo;
        }

        public Pet Create(Pet pet)
        {
            return _repo.Add(pet);
        }

        public List<Pet> ReadAll()
        {
            var list = _repo.FindAllPets();
            var orderedEnumerable = list.OrderBy(pet => pet.Price);

            return orderedEnumerable.ToList();
        }
      
        public Pet UpdatePet(Pet updatePet)
        {
            return _repo.Update(updatePet);
        }
        
        public void DeletePet(int id)
        {
            _repo.Delete(id);
        }

        public List<Pet> GetPets()
        {
            var list = _repo.FindAllPets();
            var orderedEnumerable = list.OrderBy(pet => pet.Price);

            return orderedEnumerable.ToList();
        }

        public List<Pet> SearchByPetType(string typeSearch)
        {
            var list = _repo.FindAllPets();
            var searchEnumerable = list.Where(pet => pet.Type.Name == typeSearch);

            return searchEnumerable.ToList();
        }

        public List<Pet> GetFiveCheapestPets()
        {
            var cheapPets = GetPets().Take(5);
            return cheapPets.ToList();
        }

        public Pet SearchPetById(int id)
        {
            return _repo.ReadById(id);
        }

    }
}