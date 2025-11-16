using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominio.API.Repository.Entities
{
    public class Property : IEntityBase
    {
        public Guid Id { get; set ; }
        public Guid OwnerId { get; set; }
        public string LegalId { get; set; }
        public string Tower { get; set; }
        public int Floor { get; set; }
        public string Code { get; set; }
        public virtual PropertyOwner Owner { get; set; }
    }
}
