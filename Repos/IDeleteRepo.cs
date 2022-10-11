using System;
using System.Threading.Tasks;

namespace StoreApplication.Repos
{
    public interface IDeleteRepo<T>: IRepo
    {
        public Task DeleteById (Guid id);
    }
}
