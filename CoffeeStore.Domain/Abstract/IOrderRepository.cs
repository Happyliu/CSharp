using CoffeeStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeStore.Domain.Abstract
{
    public interface IOrderRepository
    {
        Order GetOrderDetailById(int orderId);
        IEnumerable<Order> GetOrders();
        Task<int> PlaceOrder(Order order);
        Task<int> DeleteOrder(int orderId);
        IEnumerable<Order> GetOrderDetailsByCustomerID(int customerId);
    }
}
