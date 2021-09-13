using System.Collections.Generic;
using NiiO_Tech.PetShopApplication2021.Core.Models;

namespace NiiO_Tech.PetShopApplication2021.Domain.IRepositories
{
    public interface IPetRepository
    {
        Pet Add(Pet pet);
        List<Pet> FindAllPets();
        
        public Pet ReadById(int id);

        Pet Update(Pet petUpdate);

        void Delete(int petIdRemove);
    }
}