using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;

namespace PetShop.Core.ApplicationService.Service
{
    public class PetService : IPetService
    {
        private IPetRepository _petRepository;

        public PetService(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }
        public void CreatePet(Pet pet)
        {
            _petRepository.CreatePet(pet);
        }

        public void DeletePet(int id)
        {
            _petRepository.DeletePet(id);
        }

        public List<Pet> Get5CheapestPets()
        {
            return SortPetsByPrice().GetRange(0, 5);
        }

        public List<Pet> GetPets()
        {
            return _petRepository.ReadPets().ToList();
        }

        public List<Pet> SearchPets(Enum petEnum)
        {
            return _petRepository.ReadPets().Where(pet => pet.race.Equals(petEnum)).ToList();
        }

        public List<Pet> SortPetsByPrice()
        {
            List<Pet> toSort = GetPets();
            toSort.Sort((pet1, pet2) => pet1.Price.CompareTo(pet2.Price));
            return toSort;
        }

        public void UpdatePet(int id, Pet pet)
        {
            _petRepository.UpdatePet(id, pet);
        }
    }
}
