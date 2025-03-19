using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using PetStore.Data.Entities;

namespace PetStore.Data.Context
{
    public interface IPetStoreConfigsDbContext
    {
        public DbSet<Config> Configs { get; set; }

        /// <summary>
        /// Allows transaction support
        /// </summary>
        DatabaseFacade Database { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);


        /// ✅ Add this method to support `Entry()` This is for Explicit Loading
        EntityEntry Entry(object entity);
    }
}
