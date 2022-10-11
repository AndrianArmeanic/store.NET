using System;
using System.Threading.Tasks;

namespace StoreApplication.Repos
{
    public interface IReadOneRepo<T>: IRepo
    {
        public Task<T?> FindById (Guid id);
    }
}
