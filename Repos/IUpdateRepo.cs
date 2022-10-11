using System;
using System.Threading.Tasks;

namespace StoreApplication.Repos
{
    public interface IUpdateRepo<T>: IRepo
    {
        public Task<T> Update (Guid id, T data);
    }
}
