using Dapper;
using Ecommerce.Models;
using Ecommerce.Repository.Interface;
using Microsoft.Data.SqlClient;

namespace Ecommerce.Repository.Implementation
{


    public class UserRepository:IUserRepository
    {

        private readonly string _connectionstring;
        public UserRepository(IConfiguration configuration)
        {
            this._connectionstring = configuration.GetConnectionString("DefaultConnection");
        }

        public  async Task<User?> GetUser(string email)
        {
            using var connection = new SqlConnection(_connectionstring);
            var result = await connection.QueryFirstOrDefaultAsync<User>(
                """
                Select * from [Users] where email=@email
                """, new { email = email }


                );

            return result;}

        public async Task<int> Register(User user)
        {
            using var connection = new SqlConnection(_connectionstring);
            var result = await connection.ExecuteAsync(
                """
                Insert into Users(name,email,phone,password) values(
                @name,@email,@phone,@password
                )

                """, new {name=user.name,email=user.email,phone=user.phone,password=user.password }


                );
            return result;
        }
    }
}
