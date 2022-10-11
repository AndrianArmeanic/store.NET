using System;
using System.Linq;
using System.Threading.Tasks;
using StoreApplication.Attributes;
using StoreApplication.Models;

namespace StoreApplication.Repos.User
{
    [Repository]
    public class UserRepo: IUserRepo
    {
        public Task<IQueryable<UserModel>> FindAll ()
        {
            throw new NotImplementedException ();
        }

        public Task<UserModel?> FindById (Guid id)
        {
            throw new NotImplementedException ();
        }

        public Task<UserModel> Create (UserModel data)
        {
            throw new NotImplementedException ();
        }

        public Task<UserModel> Update (Guid id, UserModel data)
        {
            throw new NotImplementedException ();
        }

        public Task DeleteById (Guid id)
        {
            throw new NotImplementedException ();
        }

        public Task<UserModel?> FindByEmail (string email)
        {
            throw new NotImplementedException ();
        }
    }
}
