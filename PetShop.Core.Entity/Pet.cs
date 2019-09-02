using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.Entity
{
    public class Pet
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime SoldDate { get; set; }
        public String Color { get; set; }
        public String PreviousOwner { get; set; }
        public double Price { get; set; }
        public Race race { get; set; }

        public enum Race
        {
            Cat, Dog, Goat, Bird, Lizard
        }
    }
}
