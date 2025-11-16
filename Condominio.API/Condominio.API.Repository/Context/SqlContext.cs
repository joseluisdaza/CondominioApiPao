using Condominio.API.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace Condominio.API.Repository.Context
{
    public class SqlContext : DbContext
    {
        public const string SCHEMA = "dbo";

        public SqlContext(DbContextOptions<SqlContext> options)
            : base(options) 
        { 
        }

        // DbSets para las entidades
        public DbSet<PropertyOwner> PropertyOwners { get; set; } = null!;
        public DbSet<Property> Properties { get; set; } = null!;

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ChangeTracker.DetectChanges();
            var entries = ChangeTracker.Entries().Where(entry => entry.State.Equals(EntityState.Deleted));

            if (entries.Any())
            {
                foreach (var entry in entries)
                {
                    var entity = (IEntityBase)entry.Entity;
                    entity.IsDeleted = true;
                    entry.State = EntityState.Modified;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            // Aplicar todas las configuraciones de mapeo del assembly actual
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SqlContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
