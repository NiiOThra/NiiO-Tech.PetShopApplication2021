using System.Collections.Generic;
using System.Linq;
using NiiO_Tech.PetShopApplication2021.Core.IServices;
using NiiO_Tech.PetShopApplication2021.Core.Models;
using NiiO_Tech.PetShopApplication2021.Domain.IRepositories;

namespace NiiO_Tech.PetShopApplication2021.Domain.Services
{
    public class PetTypeService : IPetTypeService
    {

        private readonly IPetTypeRepository _petTypeRepo;
        
        public PetTypeService(IPetTypeRepository petTypeRepo)
        {
            _petTypeRepo = petTypeRepo;
        }
        
        public PetType CreatePetType(PetType petType)
        {
            return _petTypeRepo.CreateType(petType);
        }

        public List<PetType> GetPetTypes()
        {
            return _petTypeRepo.ReadPetType().ToList();
        }

        public PetType GetPetTypeById(int id)
        {
            return _petTypeRepo.ReadById(id);
        }
    }
}