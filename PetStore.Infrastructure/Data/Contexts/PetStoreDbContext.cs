using Microsoft.EntityFrameworkCore;
using PetStore.Data.Context;
using PetStore.Data.Entities;
using System.Reflection;

namespace PetStore.Infrastructure.Data.Contexts
{
    public class PetStoreDbContext : DbContext, IPetStoreDbContext
    {
        public PetStoreDbContext(DbContextOptions<PetStoreDbContext> options)
            : base(options)
        {

        }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Breed> Breeds { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Food> Food { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Pet> Pets { get; set; }

        public DbSet<Toy> Toys { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<FoodOrder> FoodOrders { get; set; }

        public DbSet<ToyOrder> ToyOrders { get; set; }

        ///// <summary>
        ///// Allows transaction support
        ///// </summary>
        //DatabaseFacade Database { get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Automatically apply all IEntityTypeConfiguration<T> classes
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseLazyLoadingProxies();
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
