using StoreApplication.Dtos.User;
using StoreApplication.Models;

namespace StoreApplication.Mappers
{
    public class UserMapper: BaseMapper<UserModel, UserDto>
    {
        public UserMapper()
        {
            // Source -> Target
            CreateMap<RegisterDto, UserModel>();
        }
    }
}
