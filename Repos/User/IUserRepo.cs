using System.Threading.Tasks;
using StoreApplication.Models;

namespace StoreApplication.Repos.User
{
    public interface IUserRepo : ICrudRepo<UserModel>
    {
        Task<UserModel?> FindByEmail (string email);
    }
}
