using PetShop.ConsoleApp.Core.Domain_Service;
using PetShop.ConsoleApp.Core.Entities;
using PetShop.ConsoleApp.Repository.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShop.ConsoleApp.Repository.Repository
{
    public class PetRepository : IPetRepository
    {

        static int id = 1;



        

        public Pet CreatePet(Pet pet)
        {
            pet.Id = id++;
            FakeDB.ListOfPets.Add(pet);
            
            return pet;

        }

        public Pet DeletePet(int id)
        {
            var petFound = this.FindById(id);
            if (petFound != null)
            {
                FakeDB.ListOfPets.Remove(petFound);
                return petFound;
            }
            return null;
        }

        public Pet EditPet(Pet updatedPet)
        {
            var petFromDB = this.FindById(id);
            if (petFromDB != null)
            {
                petFromDB.Name = updatedPet.Name;
                petFromDB.Type = updatedPet.Type;
                petFromDB.BirthDate = updatedPet.BirthDate;
                petFromDB.SoldDate = updatedPet.SoldDate;
                petFromDB.Color = updatedPet.Color;
                petFromDB.PreviousOwner = updatedPet.PreviousOwner;
                petFromDB.Price = updatedPet.Price;
                return petFromDB;
            }
            return null;
        }

        public IEnumerable<Pet> ReadAll()
        {
            
            return FakeDB.InitData();
            
        }

        public IEnumerable<Pet> ReadAllByType(string type)
        {
            var listOfPets = FakeDB.ListOfPets.ToList();
            List<Pet> listSortedByTypes = new List<Pet>();
            if (type != null)
            {
                foreach (var pet in listOfPets)
                {
                    if (pet.Type.Equals(type))
                    {
                        listSortedByTypes.Add(pet);
                    }

                }
                
            }
            return listSortedByTypes;
            
        }

        public Pet FindById(int id)
        {
            foreach (var pet in FakeDB.ListOfPets)
            {
                if (pet.Id == id)
                {
                    return pet;
                }
            }
            return null;
        }

        


    }
}
