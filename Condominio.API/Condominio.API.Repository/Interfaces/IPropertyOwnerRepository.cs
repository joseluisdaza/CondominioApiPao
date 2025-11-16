using Condominio.API.Repository.Entities;

namespace Condominio.API.Repository.Interfaces
{
    public interface IPropertyOwnerRepository : IBaseRepository<PropertyOwner>
    {
        Task<IEnumerable<Property>> GetPropertiesAsync(Guid ownerId);
    }
}
