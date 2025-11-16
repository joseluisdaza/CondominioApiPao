namespace Condominio.API.Repository.Entities
{
    public class Property : EntityBase
    {
        public Guid OwnerId { get; set; }
        public string LegalId { get; set; } = string.Empty;
        public string Tower { get; set; } = string.Empty;
        public int Floor { get; set; }
        public string Code { get; set; } = string.Empty;
        
        // Navigation property
        public virtual PropertyOwner Owner { get; set; } = null!;

        // Computed property (no se mapea a la DB)
        public string FullAddress => $"Tower {Tower}, Floor {Floor}, Code {Code}";
    }
}
