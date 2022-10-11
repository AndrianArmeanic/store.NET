using System.Threading.Tasks;

namespace StoreApplication.Repos
{
    public interface ICreateRepo<T>: IRepo
    {
        public Task<T> Create (T data);
    }
}
