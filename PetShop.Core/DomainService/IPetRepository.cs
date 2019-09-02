using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.Entity;

namespace PetShop.Core.DomainService
{
    public interface IPetRepository
    {
        IEnumerable<Pet> ReadPets();
        void CreatePet(Pet pet);
        void DeletePet(int id);
        void UpdatePet(int id, Pet pet);

    }
}
