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

        public async Task<int> PlaceOrder(Order order)
        {
            context.Orders.Add(order);
            return await context.SaveChangesAsync();
        }

        public async Task<int> DeleteOrder(int orderId)
        {
            Order dbEntry = context.Orders.Include("Lines").Where(m => m.OrderID == orderId).FirstOrDefault();
            if (dbEntry != null)
            {
                foreach (var orderline in dbEntry.Lines.ToList())
                {
                    OrderLine orderlineEntry = context.OrderLines.Where(m => m.OrderLineID == orderline.OrderLineID).FirstOrDefault();
                    context.OrderLines.Remove(orderlineEntry);
                }
                context.Orders.Remove(dbEntry);
            }
            return await context.SaveChangesAsync();
        }

        public IEnumerable<Order> GetOrderDetailsByCustomerID(int customerId)
        {
            return context.Orders.Include("Lines").Where(m => m.CustomerID == customerId);
        }

    }
}
