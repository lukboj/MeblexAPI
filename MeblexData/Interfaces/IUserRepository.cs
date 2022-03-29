using MeblexData.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeblexData.Interfaces
{
    public interface IUserRepository
    {
        Task<List<Order>> GetUserOrdersAsync(string userid);
    }
}
