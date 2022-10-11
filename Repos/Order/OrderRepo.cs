using System;
using System.Linq;
using System.Threading.Tasks;
using StoreApplication.Attributes;
using StoreApplication.Models;

namespace StoreApplication.Repos.Order
{
    [Repository]
    public class OrderRepo: IOrderRepo
    {
        public Task<OrderModel> Create (OrderModel data)
        {
            throw new NotImplementedException ();
        }

        public Task<IQueryable<OrderModel>> FindByUserId (Guid userId)
        {
            throw new NotImplementedException ();
        }

        public Task<IQueryable<OrderModel>> FindByProductId (Guid productId)
        {
            throw new NotImplementedException ();
        }
    }
}
