using PetShop.ConsoleApp.Core.Application_Service;
using PetShop.ConsoleApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShop.ConsoleApp
{
    public class Printer : IPrinter
    {

        readonly IPetService _petService;

        public Printer(IPetService petService)
        {
            _petService = petService;
        }

        
        public void StartUI()
        {
            var pet1 = new Pet()
            {
                
                Name = "Dino",
                Type = "Dog",
                BirthDate = new DateTime(2018, 4, 10),
                SoldDate = new DateTime(2018, 08, 29),
                Color = "Black",
                PreviousOwner = "Pet Store",
                Price = 20

            };

            var pet2 = new Pet()
            {
                
                Name = "Dina",
                Type = "Cat",
                BirthDate = new DateTime(2018, 4, 10),
                SoldDate = new DateTime(2018, 08, 29),
                Color = "White",
                PreviousOwner = "Pet Store",
                Price = 10

            };

            var pet3 = new Pet()
            {

                Name = "Frederik",
                Type = "Cat",
                BirthDate = new DateTime(2018, 4, 10),
                SoldDate = new DateTime(2018, 08, 29),
                Color = "White",
                PreviousOwner = "Pet Store",
                Price = 30

            };

            var pet4 = new Pet()
            {

                Name = "Louise",
                Type = "Cat",
                BirthDate = new DateTime(2018, 4, 10),
                SoldDate = new DateTime(2018, 08, 29),
                Color = "White",
                PreviousOwner = "Pet Store",
                Price = 5

            };

            var pet5 = new Pet()
            {

                Name = "Mads",
                Type = "Horse",
                BirthDate = new DateTime(2018, 4, 10),
                SoldDate = new DateTime(2018, 08, 29),
                Color = "Brown",
                PreviousOwner = "Pet Store",
                Price = 2

            };

            var pet6 = new Pet()
            {

                Name = "Daniel",
                Type = "Rhino",
                BirthDate = new DateTime(2018, 4, 10),
                SoldDate = new DateTime(2018, 08, 29),
                Color = "White",
                PreviousOwner = "Pet Store",
                Price = 50

            };

            var pet7 = new Pet()
            {

                Name = "Kent",
                Type = "Dog",
                BirthDate = new DateTime(2018, 4, 10),
                SoldDate = new DateTime(2018, 08, 29),
                Color = "White",
                PreviousOwner = "Pet Store",
                Price = 100

            };


            _petService.CreatePet(pet1);
            _petService.CreatePet(pet2);
            _petService.CreatePet(pet3);
            _petService.CreatePet(pet4);
            _petService.CreatePet(pet5);
            _petService.CreatePet(pet6);
            _petService.CreatePet(pet7);
            


            string[] menuItems =
            {
                "List all pets",
                "Create a pet",
                "Edit a pet",
                "Delete a pet",
                "Sort pets by type",
                "Sort pets by price",
                "List the 5 cheapest pets",
                "Exit"
            };

            var selection = ShowMenu(menuItems);

            while (selection != 8)
            {
                switch (selection)
                {
                    case 1:
                        var pets = _petService.ReadAll();
                        ListPets(pets);
                        break;
                    case 2:
                        var name = AskQuestion("Name: ");
                        var type = AskQuestion("Type: ");
                        var birthDate = AskQuestion("Birthday(yyyy, mm, dd): ");
                        var soldDate = AskQuestion("When were the pet last sold(yyyy, mm, dd): ");
                        var color = AskQuestion("color: ");
                        var previousOwner = AskQuestion("The name of the previous owner: ");
                        var price = AskQuestion("Price: ");
                        var pet = _petService.NewPet(name, type, Convert.ToDateTime(birthDate), Convert.ToDateTime(soldDate), color, previousOwner, Convert.ToDouble(price));
                        _petService.CreatePet(pet);
                        break;
                    case 3:
                        var idForEdit = PrintFindPetById();
                        var petToEdit = _petService.FindPetById(idForEdit);
                        Console.WriteLine("Updating " + petToEdit.Name);

                        var newName = AskQuestion("Name: ");
                        var newType = AskQuestion("Type: ");
                        var newBirthDate = AskQuestion("Birthday(yyyy, mm, dd): ");
                        var newSoldDate = AskQuestion("When were the pet last sold(yyyy, mm, dd): ");
                        var newColor = AskQuestion("color: ");
                        var newPreviousOwner = AskQuestion("The name of the previous owner: ");
                        var newPrice = AskQuestion("Price: ");
                        _petService.EditPet(new Pet()
                        {
                            Id = idForEdit,
                            Name = newName,
                            Type = newType,
                            BirthDate = Convert.ToDateTime(newBirthDate),
                            SoldDate = Convert.ToDateTime(newSoldDate),
                            Color = newColor,
                            PreviousOwner = newPreviousOwner,
                            Price = Convert.ToDouble(newPrice)
                        });
                        break;

                    case 4:
                        var idForDelete = PrintFindPetById();
                        _petService.DeletePet(idForDelete);
                        break;
                    case 5:
                        var searchedType = AskQuestion("Search a type: ");
                        var petsByType = _petService.ReadAllByType(searchedType).ToList();

                        ListPets(petsByType);
                        break;
                    case 6:
                        var petsByPrice = _petService.SortPetByPrice().ToList();
                        ListPets(petsByPrice);
                        break;
                    case 7:
                        var petsBy5Cheapest = _petService.Show5CheapestPets();
                        ListPets(petsBy5Cheapest);

                        break;
                }

                selection = ShowMenu(menuItems);
            }

            Console.WriteLine("Bye bye");
            Console.ReadLine();
        }

        private int PrintFindPetById()
        {
            Console.WriteLine("Insert Pets ID: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Insert Pets ID: ");
            }
            return id;
        }

        string AskQuestion(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }

        private void ListPets(List<Pet> pets)
        {
            Console.WriteLine("\nList of all pets\n");
            foreach (var pet in pets)
            {
                Console.WriteLine($"" +
                    $"Id: {pet.Id} " +
                    $"\nName: {pet.Name} " +
                    $"\nType: {pet.Type} " +
                    $"\nBirthday: {pet.BirthDate} " +
                    $"\nSold(Date): {pet.SoldDate} " +
                    $"\nColor: {pet.Color} " +
                    $"\nPrevious Owner: {pet.PreviousOwner} " +
                    $"\nPrice: {pet.Price}");
            }
            Console.WriteLine("\n");
        }

        int ShowMenu(string[] menuItems)
        {
            Console.WriteLine("Select What you want to do:\n");

            for (int i = 0; i < menuItems.Length; i++)
            {
                //Console.WriteLine((i + 1) + ":" + menuItems[i]);
                Console.WriteLine($"{(i + 1)}: {menuItems[i]}");
            }

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection)
                || selection < 1
                || selection > 7)
            {
                Console.WriteLine("Please select a number between 1-8");
            }

            return selection;
        }
    }
}
