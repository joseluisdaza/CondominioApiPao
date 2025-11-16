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
            // Configuración de tabla
            builder.ToTable("PropertyOwners", SqlContext.SCHEMA);
            
            // Configuración de clave primaria
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            // Configuración de propiedades
            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(100);
            
            builder.Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(100);

            // Excluir propiedades computadas
            builder.Ignore(p => p.FullName);

            // Configuración de relaciones
            builder.HasMany(p => p.Properties)
                .WithOne(p => p.Owner)
                .HasForeignKey(p => p.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);

            // Índices para mejorar rendimiento
            builder.HasIndex(p => new { p.FirstName, p.LastName })
                .HasDatabaseName("IX_PropertyOwners_FullName");
        }
    }
}
