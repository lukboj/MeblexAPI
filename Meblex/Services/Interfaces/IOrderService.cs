using Meblex.ModelsDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meblex.Services.Interfaces
{
    public interface IOrderService
    {
        Task<bool> createOrder(OrderDetailsDTO order);

        Task<List<OrderDTO>> GetUserOrders();
        Task<OrderDetailsDTO> GetUserOrderByIdAsync(int id);
    }
}
