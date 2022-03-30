using MeblexData.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeblexData.Interfaces
{
    public interface IOrderRepository
    {
        Task createOrder(Order order);

        Task<List<Order>> GetUserOrders();

        Task<Order> GetUserOrderByIdAsync(int id);
    }
}
