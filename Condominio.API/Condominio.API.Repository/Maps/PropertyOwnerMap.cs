using Condominio.API.Repository.Context;
using Condominio.API.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Condominio.API.Repository.Maps
{
    public class PropertyOwnerMap : IEntityTypeConfiguration<PropertyOwner>
    {
        public void Configure(EntityTypeBuilder<PropertyOwner> builder)
        {
            builder.ToTable("PropertyOwners", SqlContext.SCHEMA);
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id);

            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(100);
            
            builder.Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(p => p.Properties)
                .WithOne(p => p.Owner)
                .HasForeignKey(p => p.OwnerId);
        }
    }
}
