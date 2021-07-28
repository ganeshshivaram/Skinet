using System;
using Core.Entities.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.OwnsOne(x => x.ShippingAddress, a =>
            {
                a.WithOwner();
            });

            builder.Property(x => x.Status).HasConversion(
                o => o.ToString(),
                o => (OrderStatus)Enum.Parse(typeof(OrderStatus), o)
            );

            builder.HasMany(x => x.OrderItem).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }
}