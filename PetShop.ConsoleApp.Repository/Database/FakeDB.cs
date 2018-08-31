using PetShop.ConsoleApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.ConsoleApp.Repository.Database
{
    public class FakeDB
    {
        public static List<Pet> ListOfPets = new List<Pet>();

        public static List<Pet> InitData()
        {
           
            return ListOfPets;
        }
         /*

            var pet1 = new Pet()
            {
                Id = Id++,
                Name = "Dino",
                Type = "Dog",
                BirthDate = new DateTime(2018, 4, 10),
                SoldDate = new DateTime(2018, 08, 29),
                Color = "Black",
                PreviousOwner = "Pet Store",
                Price = 2.99
                
            };

            var pet2 = new Pet()
            {
                Id = Id++,
                Name = "Frederik",
                Type = "Cat",
                BirthDate = new DateTime(2018, 4, 10),
                SoldDate = new DateTime(2018, 08, 29),
                Color = "White",
                PreviousOwner = "Pet Store",
                Price = 2.99

            };


            ListOfPets.Add(pet1);
            ListOfPets.Add(pet2);
            */
    }
}
