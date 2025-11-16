namespace Condominio.API.Repository.Entities
{
    public interface IEntityBase
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
