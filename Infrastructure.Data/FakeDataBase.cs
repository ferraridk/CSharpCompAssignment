using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.Entity;
using PetShop.Core;

namespace Infrastructure.Data
{
    public class FakeDataBase
    {
        public static List<Pet> _pets = new List<Pet>();
        public static int _idCounter = 0;
        public static IEnumerable<Pet> _pp = _pets;

        public static void InitData()
        {
            _pets.Add(new Pet()
            {
                BirthDate = DateTime.Parse("01-02-2001"),
                ID = _idCounter++,
                Name = "Karen Blixen",
                Color = "Green",
                Price = 15000,
                race = Pet.Race.Lizard
                ,
                PreviousOwner = "Harald Blåtand",
                SoldDate = DateTime.Parse("01-02-2002"),

            });
            _pets.Add(new Pet()
            {
                BirthDate = DateTime.Parse("02-03-2002"),
                ID = _idCounter++,
                Name = "Dan Turell",
                Color = "Gray",
                Price = 9000,
                race = Pet.Race.Dog,
                PreviousOwner = "Christian den 9.",
                SoldDate = DateTime.Parse("08-06-1999"),
            });
            _pets.Add(new Pet()
            {
                BirthDate = DateTime.Parse("05-06-2007"),
                ID = _idCounter++,
                Name = "HC Andersen",
                Color = "Black",
                Price = 20000,
                race = Pet.Race.Dog
            });
            _pets.Add(new Pet()
            {
                BirthDate = DateTime.Parse("01-01-2019"),
                ID = _idCounter++,
                Name = "Herman Bang",
                Color = "White",
                Price = 1200,
                race = Pet.Race.Cat
            });
            _pets.Add(new Pet()
            {
                BirthDate = DateTime.Parse("10-12-2013"),
                ID = _idCounter++,
                Name = "Henrik Pontoppidan",
                Color = "Dark gray",
                Price = 100,
                race = Pet.Race.Goat

            });
            _pets.Add(new Pet()
            {
                BirthDate = DateTime.Parse("28-03-2012"),
                ID = _idCounter++,
                Name = "Leonora Christina",
                Color = "Blue",
                Price = 3000,
                race = Pet.Race.Bird
            });



        }
    }
}