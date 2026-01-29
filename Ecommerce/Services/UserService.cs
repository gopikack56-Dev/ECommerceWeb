using Ecommerce.Models;
using Ecommerce.Repository.Interface;

namespace Ecommerce.Services
{
    public class UserService:IUserService
    {


        public IUserRepository _userRepository { get; set; }
        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }


        public async  Task<int> Register(User user)
        {

            var res= await _userRepository.Register(user);
            return res;
        }


    }
}
