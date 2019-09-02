using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.Entity;

namespace PetShop.Core.ApplicationService
{
    public interface IPetService
    {
        List<Pet> GetPets();
        List<Pet> SearchPets(Enum petEnum);
        void CreatePet(Pet pet);
        void DeletePet(int id);
        void UpdatePet(int id, Pet pet);
        List<Pet> SortPetsByPrice();
        List<Pet> Get5CheapestPets();
    }
}
