using Infrastructure.Data.Repositories;
using PetShop.Core.ApplicationService;
using PetShop.Core.ApplicationService.Service;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopApp2019
{
    class ConsoleMenu : IConsoleMenu
    {
        private IPetRepository _petRepository;
        private IPetService _petService;
        private List<String> menuItemsList = new List<string>();
        public void Run()
        {

            _petRepository = new PetRepository();
            _petService = new PetService(_petRepository);
            MakeMenuItems();
            ShowMainMenu();
        }


        private void MakeMenuItems()
        {
            menuItemsList.Add("Show All Pets");
            menuItemsList.Add("Search For Pet Type");
            menuItemsList.Add("Create New Pet");
            menuItemsList.Add("Delete Pet");
            menuItemsList.Add("Update Pet");
            menuItemsList.Add("Sort Pets By Price");
            menuItemsList.Add("Get Five Cheapest Pets");
        }

        private void MakeSelection(int input)
        {
            switch (input)
            {
                case 1:
                    ShowAllPets();
                    WaitForContinue();
                    break;
                case 2:
                    FindType();
                    break;
                case 3:
                    CreatePet();
                    break;
                case 4:
                    DeletePet();
                    break;
                case 5:
                    UpdatePet();
                    break;
                case 6:
                    ListPetsByPrice();
                    break;
                case 7:
                    List5CheapestPets();
                    break;
                default:
                    Print("Choose One Of The Displayed ´Numbers");
                    MakeSelection(WaitForInt());
                    break;
            }
        }
        private void List5CheapestPets()
        {
            DisplayList(_petService.Get5CheapestPets());
            WaitForContinue();
        }

        private void ListPetsByPrice()
        {
            DisplayList(_petService.SortPetsByPrice());
            WaitForContinue();
        }

        private void UpdatePet()
        {
            ShowAllPets();
            Print("Select The Pet ID You Want To Edit");
            int id = WaitForInt();

            Print("Type New Name");
            string name = WaitForString();
            Print("Type New Color");
            string color = WaitForString();
            Print("Type New Price");
            double price = WaitForInt();
            Print("Type New Race");
            Pet.Race race = SelectType();
            Print("Type New Previous Owner");
            string prewOwner = WaitForString();
            Print("Type New Birth Date In Format Like : 01-01-2001");
            string birthDate = WaitForString();
            Print("Type New Sold Date In Format Like : 01-01-2001");
            string soldDate = WaitForString();

            Pet newPet = new Pet()
            {
                Name = name,
                Color = color,
                BirthDate = DateTime.Parse(birthDate),
                SoldDate = DateTime.Parse(soldDate),
                PreviousOwner = prewOwner,
                race = race,
                Price = price
            };
            _petService.UpdatePet(id, newPet);

            WaitForContinue();
        }

        private void DeletePet()
        {
            ShowAllPets();
            Print("Select ID To Delete");
            _petService.DeletePet(WaitForInt());
            Print("Pet Is Now Deleted");
            WaitForContinue();
        }

        private void CreatePet()
        {
            ClearConsole();
            Print("Type Name");
            string name = WaitForString();
            Print("Type Color");
            string color = WaitForString();
            Print("Type Price");
            double price = WaitForInt();
            Print("Type Race");
            Pet.Race race = SelectType();
            Print("Type Previous Owner");
            string prewOwner = WaitForString();
            Print("Type Birth Date In The Format Like : 01-01-2001");
            string birthDate = WaitForString();
            Print("Type Sold Date In The Format Like : 01-01-2001");
            string soldDate = WaitForString();

            Pet newPet = new Pet()
            {
                Name = name,
                Color = color,
                BirthDate = DateTime.Parse(birthDate),
                SoldDate = DateTime.Parse(soldDate),
                PreviousOwner = prewOwner,
                race = race,
                Price = price
            };

            _petService.CreatePet(newPet);
            WaitForContinue();
        }

        private void FindType()
        {

            DisplayList(_petService.SearchPets(SelectType()));
            WaitForContinue();
        }

        private Pet.Race SelectType()
        {
            ClearConsole();
            Print("Select a number");
            int i = 1;
            foreach (Pet.Race race in Enum.GetValues(typeof(Pet.Race)))
            {
                Print($"{i}: {race}");
                i++;
            }

            int number = -1;
            while (number < 0 || number > Enum.GetValues(typeof(Pet.Race)).Length)
            {
                number = WaitForInt();
            }
            Pet.Race selected = (Pet.Race)Enum.GetValues(typeof(Pet.Race)).GetValue(number - 1);
            return selected;
        }

        private void ShowAllPets()
        {
            DisplayList(_petService.GetPets());


        }

        private void ClearConsole()
        {
            Console.Clear();

        }
        private void WaitForContinue()
        {
            Print("Press Enter To Return");
            Console.ReadLine();
            ClearConsole();
            ShowMainMenu();
        }

        private void DisplayList(List<Pet> pets)
        {
            ClearConsole();
            foreach (Pet pet in pets)
            {
                Print($"\tID: {pet.ID}, \tName: {pet.Name}, \tColor: {pet.Color}, \tType: {pet.race}, " +
                      $"\tBirth Date: {pet.BirthDate:d}, \tPrice: {pet.Price}, " +
                      $"\tSold: {pet.SoldDate:d}, \tPrevious Owner: {pet.PreviousOwner} ");
            }
        }


        private void ShowMainMenu()
        {
            Print("Choose What You Want To Do");
            for (int i = 0; i < menuItemsList.Count; i++)
            {
                Print($"{i + 1}: {menuItemsList[i]}");
            }

            MakeSelection(WaitForInt());
        }

        private void Print(string toPrint)
        {
            Console.WriteLine(toPrint);
        }

        private int WaitForInt()
        {
            int userInput;
            if (int.TryParse(Console.ReadLine(), out userInput))
            {
                return userInput;
            }
            else
            {
                return -1;
            }
        }

        private string WaitForString()
        {
            return Console.ReadLine();
        }

    }
}
    
