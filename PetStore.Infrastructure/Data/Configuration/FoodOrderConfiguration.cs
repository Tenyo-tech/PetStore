using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetStore.Data.Entities;

namespace PetStore.Infrastructure.Data.Configuration
{
    public class FoodOrderConfiguration : IEntityTypeConfiguration<FoodOrder>
    {
        public void Configure(EntityTypeBuilder<FoodOrder> foodOrder)
        {
            //Test without
            //foodOrder.HasKey(to => new { to.FoodId, to.OrderId });

            foodOrder
                .HasOne(fo => fo.Order)
                .WithMany(o => o.Food)
                .HasForeignKey(fo => fo.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            foodOrder
                .HasOne(fo => fo.Food)
                .WithMany(f => f.Orders)
                .HasForeignKey(fo => fo.FoodId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
