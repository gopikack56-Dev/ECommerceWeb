
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Ecommerce.Server
{
    public class AuthenticationManager : IAuthenticationManager
    {
        public readonly string key;
        public AuthenticationManager(string key)
        {
            this.key = key;
        }

        public  async Task<string> TokenGeneration(string email)
        {

            var tokenhandler = new JwtSecurityTokenHandler();

            var tokenkey = Encoding.ASCII.GetBytes(key);



            var tokenDescriptor = new SecurityTokenDescriptor()
            {

                Subject = new ClaimsIdentity([
                           new Claim(ClaimTypes.Email,email)      ]
                    ),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenkey),
                    SecurityAlgorithms.HmacSha256Signature),
                IssuedAt = DateTime.UtcNow,
                Issuer="App.Identity",
                Audience="Audience.Main"


            };

            var token = tokenhandler.CreateToken(tokenDescriptor);

            return tokenhandler.WriteToken(token);




          
        }



    }
}
