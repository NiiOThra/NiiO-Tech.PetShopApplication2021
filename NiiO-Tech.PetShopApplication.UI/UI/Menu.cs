using System;
using NiiO_Tech.PetShopApplication2021.Core.IServices;
using NiiO_Tech.PetShopApplication2021.Core.Models;
using static System.Console;

namespace NiiO_Tech.PetShopApplication.UI
{
    public class Menu
    {
        private readonly IPetService _service;
        private readonly IPetTypeService _petTypeService;
        
        public Menu(IPetService petService, IPetTypeService petTypeService)
        {
            _service = petService;
            _petTypeService = petTypeService;
        }

        public void Start()
        {
            ShowWelcomeMessage();
            StartLoop();
        }
        private void StartLoop()
        {
            int choice;
            while ((choice = GetMainMenuSelection()) != 0)
            {
                {
                    if (choice == 1)
                    { 
                        CreatePet();
                    }
                    if (choice == 2)
                    { 
                        ReadAllPets();
                    }
                    if (choice == 3)
                    { 
                        UpdatePet();
                    }
                    if (choice == 4)
                    { 
                        DeletePet();
                    }
                    if (choice == 5)
                    { 
                        SearchByPetType();
                    } 
                    if (choice == 6) 
                    { 
                        GetFiveCheapestPets();
                    }
                    
                }
            }
        }

        

        private int GetMainMenuSelection()
        {
            ShowMainMenu();
            PrintNewLine();
            var selectionString = ReadLine();
            if (int.TryParse(selectionString, out var selection))
            {
                return selection;
            }
            return -1;
        }
        
        private void ShowMainMenu()
        {
            PrintNewLine();
            Print(StringConstants.SelectionMenu);
            PrintNewLine();
            Print(StringConstants.CreatePet);
            Print(StringConstants.ShowAllPetsAvailable);
            Print(StringConstants.UpdatePet);
            Print(StringConstants.DeletePet);
            Print(StringConstants.SearchByAnimal);
            Print(StringConstants.SortPetByPrice);
            Print(StringConstants.ExitMainMenu);
        }
        
        private void SearchByPetType()
        {
            Print(StringConstants.SearchForAnimalType);
            var typeSearch = ReadLine();

            foreach (var pet in _service.SearchByPetType(typeSearch))
            {
                Print($"Name: {pet.Name}, Born on: {pet.BirthDate}, " +
                      $"\nColor: {pet.Color}, Price: {pet.Price}, Sold on: {pet.SoldDate}, Id: {pet.Id}");
                PrintNewLine();
            }
        }

        private void GetFiveCheapestPets()
        {
            Print(StringConstants.FiveCheapestPets);
            PrintNewHyphenLine();
            foreach (var pet in _service.GetFiveCheapestPets())
            {
                Print($"Name: {pet.Name}, Born on: {pet.BirthDate}, " +
                      $"\nColor: {pet.Color}, Price: {pet.Price}, Sold on: {pet.SoldDate}, Id: {pet.Id}");
                PrintNewLine();
            }
        }
        
        
        
        private void CreatePet()
        {
            Print(StringConstants.PetCreatorMessage);
            
            Print(StringConstants.PetType);
            PrintNewLine();
            ReadAllTypes();
            int typeId = int.Parse(ReadLine()!);
            PetType petType = _petTypeService.GetPetTypeById(typeId);
            
            
            Print(StringConstants.PetName);
            PrintNewLine();
            var petName = ReadLine();
            
            Print(StringConstants.PetBirthDate);
            PrintNewLine();
            var petBirthDate = DateTime.Parse(ReadLine()!);
            
            Print(StringConstants.PetSoldDate);
            PrintNewLine();
            var petSoldDate = DateTime.Parse(ReadLine()!);
            
            Print(StringConstants.PetColor);
            PrintNewLine();
            var petColor = ReadLine();
            
            Print(StringConstants.PetPrice);
            PrintNewLine();
            var petPrice = double.Parse(ReadLine()!);
            
            var pet = new Pet()
            {
                Name = petName,
                BirthDate = petBirthDate,
                SoldDate = petSoldDate,
                Type = petType,
                Color = petColor,
                Price = petPrice

            };
            pet = _service.Create(pet);
            Print($"The following pet was created:\nId: {pet.Id}\nPet type: {pet.Type.Name}\nName: {pet.Name}\nColor: {pet.Color}\nBorn on: {pet.BirthDate}\nPrice: {pet.Price}\nSold at: {pet.SoldDate}");

        }
        
        private void PrintNewLine()
        {
            WriteLine("");
        }
        private void PrintNewHyphenLine()
        {
            WriteLine("---------------------------------------------");
        }
        
        private void Print(string value)
        {
            WriteLine(value);
        }
        
        public void ShowWelcomeMessage()
        {
            WriteLine(StringConstants.WelcomeGreeting);
        }

        private void ReadAllPets()
        {
            foreach (var pet in _service.GetPets())
            {
                Print($"Name: {pet.Name}, Pet type: {pet.Type.Name}, Born on: {pet.BirthDate}, " +
                      $"\nColor: {pet.Color}, Price: {pet.Price}, Sold on: {pet.SoldDate}, Id: {pet.Id}");
                PrintNewLine();
            }
        }
        
        private void ReadAllTypes()
        {
            foreach (var type in _petTypeService.GetPetTypes())
            {
                Print($"Id: {type.Id}, Type: {type.Name}");
            }
        }

        public void StartData()
        {
            var pet1 = new Pet()
            {
                Name = "Jørn",
                Type = _petTypeService.CreatePetType(new PetType() {Name = "Gorilla"}),
                BirthDate = new DateTime(2005, 4, 4),
                SoldDate = new DateTime(2009, 9, 8),
                Color = "Silver",
                Price = 26999
            };
            _service.Create(pet1);
            
            var pet2 = new Pet()
            {
                Name = "Snek",
                Type = _petTypeService.CreatePetType(new PetType() {Name = "Snake"}),
                BirthDate = new DateTime(2019, 12, 24),
                SoldDate = new DateTime(2020, 1, 4),
                Color = "Black",
                Price = 350
            };
            _service.Create(pet2);
            
            var pet3 = new Pet()
            {
                Name = "Perry",
                Type = _petTypeService.CreatePetType(new PetType() {Name = "Platypus"}),
                BirthDate = new DateTime(2018, 4, 16),
                SoldDate = new DateTime(2021, 1, 7),
                Color = "Teal",
                Price = 2500
            };
            _service.Create(pet3);
            
            var pet4 = new Pet()
            {
                Name = "Jens",
                Type = _petTypeService.CreatePetType(new PetType() {Name = "Puffin"}),
                BirthDate = new DateTime(2019, 7, 24),
                SoldDate = new DateTime(2020, 2, 28),
                Color = "Black and White",
                Price = 159
            };
            _service.Create(pet4);
            var pet5 = new Pet()
            {
                Name = "Jens",
                Type = _petTypeService.CreatePetType(new PetType() {Name = "Turtle"}),
                BirthDate = new DateTime(1895, 3, 9),
                SoldDate = new DateTime(1995, 1, 8),
                Color = "Greenish",
                Price = 1_000_000
            };
            _service.Create(pet5);
        }
        

        private void UpdatePet()
        {
            Print(StringConstants.WhatIdToSearchFor);
            var updateId = int.Parse(ReadLine()!);
            var updatePet = _service.SearchPetById(updateId);
            
            Print(StringConstants.UpdatedPetName);
            var updatedName = ReadLine();
            
            Print(StringConstants.UpdatedPrice);
            var updatedPrice = double.Parse(ReadLine()!);

            _service.UpdatePet(new Pet()
            {
                Id = updatePet.Id,
                Name = updatedName,
                Type = updatePet.Type,
                Color = updatePet.Color,
                BirthDate = updatePet.BirthDate,
                SoldDate = updatePet.SoldDate,
                Price = updatedPrice
                
            });
            Print($"{updatePet.Name} was updated.");
        }
        
        private void DeletePet()
        {
            Print(StringConstants.DeletePetById);
            var petIdDelete = int.Parse(ReadLine()!);
            _service.DeletePet(petIdDelete);
        }
    }
}