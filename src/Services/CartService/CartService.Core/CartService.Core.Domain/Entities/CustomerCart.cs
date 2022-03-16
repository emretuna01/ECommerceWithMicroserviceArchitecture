using CartService.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartService.Core.Domain.Entities
{
    public class CustomerCart : BaseEntity
    {
        public Guid BuyerId { get; set; }        
        public User Buyer { get; set; }
        public List<CatalogItem> Items { get; set; }
        public CartStatus CartStatus { get; set; } = CartStatus.Start;
    }
}
