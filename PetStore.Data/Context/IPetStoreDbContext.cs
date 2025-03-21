﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using PetStore.Data.Entities;

namespace PetStore.Data.Context
{
    public interface IPetStoreDbContext
    {
        DbSet<Brand> Brands { get; set; }

        DbSet<Breed> Breeds { get; set; }

        DbSet<Category> Categories { get; set; }

        DbSet<Food> Food { get; set; }

        DbSet<Order> Orders { get; set; }

        DbSet<Pet> Pets { get; set; }

        DbSet<Toy> Toys { get; set; }

        DbSet<User> Users { get; set; }

        DbSet<FoodOrder> FoodOrders { get; set; }

        DbSet<ToyOrder> ToyOrders { get; set; }

        /// <summary>
        /// Allows transaction support
        /// </summary>
        DatabaseFacade Database { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);


        /// ✅ Add this method to support `Entry()` This is for Explicit Loading
        EntityEntry Entry(object entity);
    }
}
