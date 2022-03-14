using OrderService.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Core.Domain.Entities
{
    public class OrderItem:BaseEntity
    {
        public Guid BuyerId { get; set; }

        [ForeignKey("BuyerId")]
        public User Buyer { get; set; }

        public List<CustomerCart> Carts { get; set; }
        public string City { get; set; }

        public string Street { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string ZipCode { get; set; }

        public string CardNumber { get; set; }

        public string CardHolderName { get; set; }

        public DateTime CardExpiration { get; set; }

        public string CardSecurityNumber { get; set; }
        
    }
}
