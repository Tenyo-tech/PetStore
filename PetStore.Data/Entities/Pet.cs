﻿using System.ComponentModel.DataAnnotations;

namespace PetStore.Data.Entities
{
    public class Pet
    {
        public int Id { get; set; }

        public Gender Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public decimal Price { get; set; }

        [MaxLength(DataValidation.DescriptionMaxLength)]
        public string Description { get; set; } = string.Empty;

        public int BreedId { get; set; }

        public Breed Breed { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public int? OrderId { get; set; }

        public Order Order { get; set; }
    }
}
