using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetStore.Data.Entities;

namespace PetStore.Infrastructure.Data.Configuration
{
    public class ToyConfiguration : IEntityTypeConfiguration<Toy>
    {
        public void Configure(EntityTypeBuilder<Toy> toy)
        {
            toy
               .HasMany(t => t.Orders)
               .WithOne(to => to.Toy)
               .HasForeignKey(to => to.ToyId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
