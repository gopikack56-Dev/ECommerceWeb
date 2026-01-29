using Ecommerce.Models;
using Ecommerce.Repository.Interface;
using Ecommerce.Server;

namespace Ecommerce.Services
{
    public class LoginService : ILoginService
    {

        public  IUserRepository _userRepository{ get; set; }
        public IAuthenticationManager _authenticationManager { get; set; }

        public LoginService(IUserRepository userRepository,IAuthenticationManager authenticationManager)
        {
            _userRepository = userRepository;
            _authenticationManager = authenticationManager;
        }
        public async Task<User?> GetUser(string email)
        {
           var result= await  _userRepository.GetUser(email);
            return result;
        }

        public async Task<string> Authenticate(string email,string password)
        {

            var user = await GetUser(email);
            if(user==null)
            {

                return null;
            }
            if(user.password!=password)
            {
                return null;
            }

            return await _authenticationManager.TokenGeneration(email);





        }








    }
}
