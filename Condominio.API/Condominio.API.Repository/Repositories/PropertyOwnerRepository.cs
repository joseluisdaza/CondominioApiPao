using Condominio.API.Repository.Context;
using Condominio.API.Repository.Entities;
using Condominio.API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Condominio.API.Repository.Repositories
{
    public class PropertyOwnerRepository : BaseRepository<PropertyOwner>, IPropertyOwnerRepository
    {
        public PropertyOwnerRepository(SqlContext context) : base(context)
        {
        }

        public virtual async Task<IEnumerable<Property>> GetPropertiesAsync(Guid ownerId)
        {
            return await Context.Set<Property>().Where(p => p.OwnerId == ownerId).ToListAsync();
        }
    }
}
