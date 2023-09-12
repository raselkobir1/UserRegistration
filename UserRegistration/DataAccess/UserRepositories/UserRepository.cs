using Dapper;
using System.Data.SqlClient;
using UserRegistration.DataAccess.Entity;
using static Dapper.SqlMapper;

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
            entity.Password = BCrypt.Net.BCrypt.HashPassword(entity.Password.Trim());
            entity.Email = entity.Email.Trim();
            entity.MobileNumber = entity.MobileNumber.Trim();   
            entity.UserName = entity.UserName.Trim();

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

        public async Task<User> GetByUserName(string userName) 
        {
            try
            {
                var sql = "SELECT FullName, UserName, Email, Address, MobileNumber FROM dbo.[User] WHERE UserName = @UserName";
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var result = await connection.QuerySingleOrDefaultAsync<User>(sql, new { UserName = userName });  
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
