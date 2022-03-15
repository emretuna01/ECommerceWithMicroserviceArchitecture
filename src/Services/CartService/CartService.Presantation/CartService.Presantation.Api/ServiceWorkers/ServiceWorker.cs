using CartService.Core.Domain.Entities;

namespace CartService.Presantation.Api.ServiceWorkers
{
    public class ServiceWorker
    {
        
        public void CartStatusFinisher(ref CustomerCart customerCart)
        {
            customerCart.CartStatus = CartStatus.Done;
        }
    }
}
