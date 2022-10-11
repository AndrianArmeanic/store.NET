using System.Linq;
using System.Threading.Tasks;

namespace StoreApplication.Repos
{
    public interface IReadManyRepo<T>: IRepo
    {
        public Task<IQueryable<T>> FindAll ();
    }
}
