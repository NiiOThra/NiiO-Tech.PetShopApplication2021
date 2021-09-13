using System;

namespace NiiO_Tech.PetShopApplication2021.Core.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PetType Type { get; init; }
        public DateTime BirthDate { get; init; }
        public DateTime SoldDate { get; init; }
        public double Price { get; set; }
        public string Color { get; init; }
    }
}