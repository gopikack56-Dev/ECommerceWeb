using Ecommerce.Models;

namespace Ecommerce.Services
{
    public interface IUserService
    {


        public Task<int> Register(User user);
    }
}
