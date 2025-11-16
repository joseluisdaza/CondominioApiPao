using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominio.API.Repository.Entities
{
    public class EntityBase : IEntityBase
    {
        public Guid Id { get; set; }
    }
}
