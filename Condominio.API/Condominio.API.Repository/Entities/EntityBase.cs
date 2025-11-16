namespace Condominio.API.Repository.Entities
{
    public abstract class EntityBase : IEntityBase
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
