using OrderService.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Core.Domain.Entities
{
    public class CustomerCart : BaseEntity
    {
        
        public Guid BuyerId { get; set; }

        [ForeignKey("BuyerId")]
        public User Buyer { get; set; }

        public List<CatalogItem> Items { get; set; }
        public CartStatus CartStatus { get; set; } = CartStatus.Start;
    }
}
