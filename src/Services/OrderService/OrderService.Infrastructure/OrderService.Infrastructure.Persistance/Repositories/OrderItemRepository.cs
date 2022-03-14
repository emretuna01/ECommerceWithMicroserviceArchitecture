using OrderService.Core.Application.Interfaces.Repositories;
using OrderService.Core.Domain.Entities;
using OrderService.Infrastructure.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Infrastructure.Persistance.Repositories
{
    public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
