using AutoMapper;
using Meblex.ModelsDTO;
using Meblex.Services.Interfaces;
using MeblexData.Interfaces;
using MeblexData.Models.Order;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meblex.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderrepository;

        private readonly IMapper mapper;

        public OrderService(IOrderRepository orderRepositry, IMapper mapper)
        {
            this.orderrepository = orderRepositry;
            this.mapper = mapper;
        }

        public async Task<bool> createOrder(OrderDetailsDTO order)
        {
            if (order != null)
            {

                    var ordertocreate = mapper.Map<Order>(order);
                    await orderrepository.createOrder(ordertocreate);
                    return true;
                

            }
            return false;

        }

        public async Task<OrderDetailsDTO> GetUserOrderByIdAsync(int id)
        {
            var orders = await orderrepository.GetUserOrderByIdAsync(id);
            var ordertodto = mapper.Map<OrderDetailsDTO>(orders);
            return ordertodto;
        }
        public async Task<List<OrderDTO>> GetUserOrders()
        {
            var orders = await orderrepository.GetUserOrders();
            var orderstodto = mapper.Map<List<OrderDTO>>(orders);
            return orderstodto;
        }

    }
}
