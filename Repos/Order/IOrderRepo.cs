using System;
using System.Linq;
using System.Threading.Tasks;
using StoreApplication.Models;

namespace StoreApplication.Repos.Order
{
    public interface IOrderRepo: ICreateRepo<OrderModel>
    {
        Task<IQueryable<OrderModel>> FindByUserId (Guid userId);

        Task<IQueryable<OrderModel>> FindByProductId (Guid productId);
    }
}
