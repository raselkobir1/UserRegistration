using UserRegistration.DataAccess.UnitOfWorks;
using UserRegistration.DataAccess.UserRepositories;

namespace UserRegistration
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>(); 
        }   
    }
}
