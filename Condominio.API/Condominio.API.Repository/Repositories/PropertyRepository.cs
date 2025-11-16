using Condominio.API.Repository.Context;
using Condominio.API.Repository.Entities;
using Condominio.API.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominio.API.Repository.Repositories
{
    public class PropertyRepository : BaseRepository<Property>, IPropertyRepository
    {
        public PropertyRepository(SqlContext context) : base(context)
        {
        }
    }
}
