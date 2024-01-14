using System.Collections.Generic;
using System.Threading.Tasks;
using ECOMMERCE.Models;

namespace ECOMMERCE.Repositories
{
    public interface IUserOrderRepository
    {
        Task<IEnumerable<Order>> UserOrders();
    }
}
