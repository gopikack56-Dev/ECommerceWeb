using Ecommerce.Models;

namespace Ecommerce.Services
{
    public interface ILoginService
    {

        public Task<User?> GetUser(string email);

        public Task<string> Authenticate(string email,string password);

       
    }
}
