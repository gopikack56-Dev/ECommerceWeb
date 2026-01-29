using Ecommerce.Models;

namespace Ecommerce.Repository.Interface
{
    public interface IUserRepository
    {

        public Task<User?> GetUser(string email);

        public Task<int> Register(User user);


    }
}
