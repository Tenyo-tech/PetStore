using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetStore.Data.Entities;

namespace PetStore.Infrastructure.Data.Configuration
{
    public class BreedConfiguration : IEntityTypeConfiguration<Breed>
    {
        public void Configure(EntityTypeBuilder<Breed> breed)
        {
            //Test if throws an error on migration
            //breed.HasKey(b => b.Id);
        }
    }
}
