namespace Ecommerce.Server
{
    public interface IAuthenticationManager
    {

        public Task<string> TokenGeneration(string email);
    }
}
