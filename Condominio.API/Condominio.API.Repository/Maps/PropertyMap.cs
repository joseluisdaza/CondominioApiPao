using Condominio.API.Repository.Context;
using Condominio.API.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Condominio.API.Repository.Maps
{
    public class PropertyMap : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            // Configuración de tabla
            builder.ToTable("Properties", SqlContext.SCHEMA);
            
            // Configuración de clave primaria
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            // Configuración de propiedades
            builder.Property(p => p.LegalId)
                .HasMaxLength(50);
            
            builder.Property(p => p.Tower)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Floor)
                .IsRequired();
            
            builder.Property(p => p.Code)
                .IsRequired()
                .HasMaxLength(10);

            // Configuración de clave foránea
            builder.Property(p => p.OwnerId)
                .IsRequired();

            // Excluir propiedades computadas
            builder.Ignore(p => p.FullAddress);

            // Configuración de relaciones
            builder.HasOne(p => p.Owner)
                .WithMany(p => p.Properties)
                .HasForeignKey(p => p.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);

            // Índices para mejorar rendimiento
            builder.HasIndex(p => p.LegalId)
                .IsUnique()
                .HasDatabaseName("IX_Properties_LegalId");
            
            builder.HasIndex(p => p.Code)
                .HasDatabaseName("IX_Properties_Code");
            
            builder.HasIndex(p => p.OwnerId)
                .HasDatabaseName("IX_Properties_OwnerId");
        }
    }
}
