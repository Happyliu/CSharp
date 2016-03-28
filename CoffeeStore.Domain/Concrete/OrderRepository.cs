using CoffeeStore.Domain.Abstract;
using CoffeeStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeStore.Domain.Concrete
{
    public class OrderRepository : IOrderRepository
    {

        private EFDbContext context = new EFDbContext();

        public IEnumerable<Order> GetOrders()
        {
            return context.Orders.Include("Lines");
        }

        public Order GetOrderDetailById(int orderId)
        {
            return context.Orders.Find(orderId);
        }


    }
}
