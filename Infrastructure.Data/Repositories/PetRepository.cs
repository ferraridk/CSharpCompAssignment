using PetShop.Core.DomainService;
using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.Repositories
{
    public class PetRepository : IPetRepository
    {
        public PetRepository()
        {
            FakeDataBase.InitData();
        }

        public IEnumerable<Pet> ReadPets()
        {
            return FakeDataBase._pp;
        }

        public void CreatePet(Pet pet)
        {
            pet.ID = FakeDataBase._idCounter++;
            FakeDataBase._pets.Add(pet);
        }

        public void DeletePet(int id)
        {
            int index = -1;
            for (int i = 0; i < FakeDataBase._pets.Count; i++)
            {
                if (FakeDataBase._pets[i].ID.Equals(id))
                {
                    index = i;
                    break;
                }
            }

            FakeDataBase._pets.RemoveAt(index);
        }

        public void UpdatePet(int id, Pet pet)
        {
            pet.ID = id;
            for (int i = 0; i < FakeDataBase._pets.Count; i++)
            {
                if (FakeDataBase._pets[i].ID.Equals(id))
                {
                    FakeDataBase._pets[i] = pet;
                    break;
                }
            }

        }
    }
}

