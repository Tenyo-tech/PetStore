using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetStore.Data.Entities;

namespace PetStore.Infrastructure.Data.Configuration
{
    public class FoodConfiguration : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> food)
        {
            food.HasKey(f => f.Id);
        }
    }
}
