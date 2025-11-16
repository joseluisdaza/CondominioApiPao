using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominio.API.Repository.Entities
{
    public class PropertyOwner : IEntityBase
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Property> Properties { get; set; }
    }
}
