using Microsoft.EntityFrameworkCore;
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

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
