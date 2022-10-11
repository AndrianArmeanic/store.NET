using System.Threading.Tasks;
using StoreApplication.Models;

namespace StoreApplication.Repos.Product
{
    public interface IProductRepo : ICrudRepo<ProductModel>
    {
        Task<ProductModel?> FindByName (string name);
    }
}
