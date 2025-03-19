using Microsoft.EntityFrameworkCore;
using PetStore.Data.Context;
using PetStore.Data.Entities;

namespace PetStore.Infrastructure.Data.Contexts
{
    public class PetStoreConfigsDbContext : DbContext, IPetStoreConfigsDbContext
    {
        public PetStoreConfigsDbContext(DbContextOptions<PetStoreConfigsDbContext> options)
            : base(options)
        {

        }


        public DbSet<Config> Configs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ✅ Only apply configurations for Config entity
            modelBuilder.Entity<Config>().ToTable("Configs");
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
