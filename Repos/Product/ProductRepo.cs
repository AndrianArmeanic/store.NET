using System;
using System.Linq;
using System.Threading.Tasks;
using StoreApplication.Attributes;
using StoreApplication.Models;

namespace StoreApplication.Repos.Product
{
    [Repository]
    public class ProductRepo: IProductRepo
    {
        public Task<IQueryable<ProductModel>> FindAll ()
        {
            throw new NotImplementedException ();
        }

        public Task<ProductModel?> FindById (Guid id)
        {
            throw new NotImplementedException ();
        }

        public Task<ProductModel> Create (ProductModel data)
        {
            throw new NotImplementedException ();
        }

        public Task<ProductModel> Update (Guid id, ProductModel data)
        {
            throw new NotImplementedException ();
        }

        public Task DeleteById (Guid id)
        {
            throw new NotImplementedException ();
        }

        public Task<ProductModel?> FindByName (string name)
        {
            throw new NotImplementedException ();
        }
    }
}
