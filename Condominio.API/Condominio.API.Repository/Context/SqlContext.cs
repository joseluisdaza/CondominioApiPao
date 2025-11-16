using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Condominio.API.Repository.Context
{
    public class SqlContext : DbContext
    {
        public static string SchemaImporter = "dbo";

        public SqlContext(DbContextOptions<SqlContext>options)
            :base(options){ }
        //va a definir que mapas vamos a tener 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            // de donde va a sacar la informacion para generar la migracion 
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SqlContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
