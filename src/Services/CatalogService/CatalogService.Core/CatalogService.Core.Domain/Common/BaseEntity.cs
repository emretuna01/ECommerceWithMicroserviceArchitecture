using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Core.Domain.Common
{
    public class BaseEntity
    {
        [Key]
        public Guid ObjectId { get; set; }
    }
}
