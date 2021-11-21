using SportsShop.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsShop.WebApi.Services
{
    interface IOrderService
    {
        Task<IEnumerable<order>> GetOrderList();
        Task<order> GetOrderById(int id);
        Task<order> CreateOrder(order order);
        Task UpdateOrder(order order);
        Task DeleteOrder(order order);
    }
}
