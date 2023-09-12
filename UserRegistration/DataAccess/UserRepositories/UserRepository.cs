using Dapper;
using System.Data.SqlClient;
using UserRegistration.DataAccess.Entity;

namespace UserRegistration.DataAccess.UserRepositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration configuration;
        public UserRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<long> AddAsync(User entity) 
        {
            entity.Password = BCrypt.Net.BCrypt.HashPassword(entity.Password);

            try
            {
                var sql = @"INSERT INTO dbo.[User] (FullName,UserName,Password,Email,Address,MobileNumber) 
                                    OUTPUT Inserted.Id 
                                    VALUES (@FullName,@UserName,@Password,@Email,@Address,@MobileNumber)";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var result = await connection.ExecuteAsync(sql, entity);
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
