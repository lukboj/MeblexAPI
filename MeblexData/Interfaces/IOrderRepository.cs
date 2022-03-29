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
        void createOrder(Order order);

        List<Order> GetUserOrders();

        Task<Order> GetUserOrderByIdAsync(int id);
    }
}
