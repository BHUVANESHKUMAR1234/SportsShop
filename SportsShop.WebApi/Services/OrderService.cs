using SportsShop.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsShop.WebApi.Services
{
    public class OrderService : IOrderService
    {
        public Task<order> CreateOrder(order order)
        {
            throw new NotImplementedException();
        }

        public Task DeleteOrder(order order)
        {
            throw new NotImplementedException();
        }

        public Task<order> GetOrderById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<order>> GetOrderList()
        {
            throw new NotImplementedException();
        }

        public Task UpdateOrder(order order)
        {
            throw new NotImplementedException();
        }
    }
}
