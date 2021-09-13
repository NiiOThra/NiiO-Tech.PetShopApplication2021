using System.Collections.Generic;
using NiiO_Tech.PetShopApplication2021.Core.Models;

namespace NiiO_Tech.PetShopApplication2021.Core.IServices
{
    public interface IPetTypeService
    {
        PetType CreatePetType(PetType petType);
        PetType GetPetTypeById(int id);
        List<PetType> GetPetTypes();

        
    }
}