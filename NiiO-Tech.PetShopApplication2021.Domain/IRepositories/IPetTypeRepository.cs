using System.Collections.Generic;
using NiiO_Tech.PetShopApplication2021.Core.Models;

namespace NiiO_Tech.PetShopApplication2021.Domain.IRepositories
{
    public interface IPetTypeRepository
    {
        PetType CreateType(PetType petType);
        List<PetType> ReadPetType();
        PetType ReadById(int id);
    }
}