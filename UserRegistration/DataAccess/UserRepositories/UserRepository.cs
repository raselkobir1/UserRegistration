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

        public Task<long> DeleteAsync(long id, long userId)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<long> UpdateAsync(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
