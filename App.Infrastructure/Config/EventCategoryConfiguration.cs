using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Infrastructure.Config
{
    public class EventCategoryConfiguration : IEntityTypeConfiguration<EventCategory>
    {
        public void Configure(EntityTypeBuilder<EventCategory> builder)
        {
            builder.ToTable("EventCategories", "org");

            builder.HasIndex(a => a.PublicId).IsUnique()
                 .IsClustered(false);

            builder.Property(a => a.Name)
                .HasColumnType("NVARCHAR(255)")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(a => a.Description)
                .HasColumnType("NVARCHAR(4000)")
                .IsRequired(false);

        }
    }
}
