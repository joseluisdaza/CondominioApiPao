namespace Condominio.API.Repository.Entities
{
    public class PropertyOwner : EntityBase
    {

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        
        // Navigation property
        public virtual ICollection<Property> Properties { get; set; }

        // Computed property (no se mapea a la DB)
        public string FullName => $"{FirstName} {LastName}".Trim();
        public PropertyOwner()
        {
            Properties = new HashSet<Property>();
        }
    }
}
