﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CarOrders.Domain.Models;
using CarOrders.Domain.ValueObjects;

namespace CarOrders.Infrastructure.Data.Configurations;
public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasKey(oi => oi.Id);

        builder.Property(oi => oi.Id).HasConversion(
                                   orderItemId => orderItemId.Value,
                                   dbId => OrderItemId.Of(dbId));

        builder.HasOne<Car>()
            .WithMany()
            .HasForeignKey(oi => oi.CarId);

        builder.Property(oi => oi.Quantity).IsRequired();

        builder.Property(oi => oi.Price).IsRequired();
    }
}
