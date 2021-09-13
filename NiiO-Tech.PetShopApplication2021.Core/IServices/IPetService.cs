using System.Collections;
using System.Collections.Generic;
using NiiO_Tech.PetShopApplication2021.Core.Models;

namespace NiiO_Tech.PetShopApplication2021.Core.IServices
{
    public interface IPetService
    {
        Pet Create(Pet pet);
        List<Pet> ReadAll();
        void DeletePet(int id);
        List<Pet> GetPets();
        List<Pet> SearchByPetType(string typeSearch);
        public List<Pet> GetFiveCheapestPets();
        
        Pet SearchPetById(int id);
        Pet UpdatePet(Pet pet);
    }
}