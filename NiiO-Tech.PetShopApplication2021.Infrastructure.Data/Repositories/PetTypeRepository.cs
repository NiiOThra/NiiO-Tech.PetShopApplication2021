using System.Collections.Generic;
using System.Linq;
using NiiO_Tech.PetShopApplication2021.Core.Models;
using NiiO_Tech.PetShopApplication2021.Domain.IRepositories;

namespace NiiO_Tech.PetShopApplication2021.Infrastructure.Data.Repositories
{
    public class PetTypeRepository : IPetTypeRepository
    {
        private static readonly List<PetType> PetTypes = new List<PetType>();
        private static int _petTypeId = 1;

        public PetType CreateType(PetType petType)
        {
            petType.Id = _petTypeId++;
            PetTypes.Add(petType);
            return petType;
        }

        public List<PetType> ReadPetType()
        {
            return PetTypes;
        }

        public PetType ReadById(int id)
        {
            return PetTypes.FirstOrDefault(petType => petType.Id == id);
        }
    }
}