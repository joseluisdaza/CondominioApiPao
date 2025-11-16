using Condominio.API.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Condominio.API.Repository.Maps
{
    public class PropertyMap : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.ToTable("Properties", Context.SqlContext.SCHEMA);
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedNever();

            builder.Property(p => p.LegalId)
                .IsRequired()
                .HasMaxLength(50);
            
            builder.Property(p => p.Tower)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Floor)
                .IsRequired();
            
            builder.Property(p => p.Code)
                .IsRequired()
                .HasMaxLength(10);

            builder.HasOne(p => p.Owner)
                .WithMany(p => p.Properties)
                .HasForeignKey(p => p.OwnerId);

        }
    }
}
