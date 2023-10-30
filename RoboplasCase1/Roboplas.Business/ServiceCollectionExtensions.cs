using Microsoft.Extensions.DependencyInjection;
using Roboplas.Business.Implementations;
using Roboplas.Business.Interfaces;
using Roboplas.Business.Profiles;
using Roboplas.DataAccess.EF.Repositories;
using Roboplas.DataAccess.Interfaces;

namespace Roboplas.Business
{
    public static class ServiceCollectionExtensions
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(UserProfile));

            services.AddScoped<IUserBs, UserBs>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IDutyBs, DutyBs>();
            services.AddScoped<IDutyRepository, DutyRepository>();
        }
    }
}
