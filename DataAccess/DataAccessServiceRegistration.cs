using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameworkDal;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class DataAccessServiceRegistration
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
        {

            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            if(env is "Development")
            {
                services.AddDbContext<BaseDbContext, LibraryAppInMemoryContext>(ServiceLifetime.Transient);
            }
            else
            {
                services.AddDbContext<BaseDbContext, LibraryAppMsSqlContext>(ServiceLifetime.Transient);
            }

            

            services.AddScoped<IUserDal, EfUserDal>();
            services.AddScoped<IRoleDal, EfRoleDal>();
            services.AddScoped<IUserRoleDal, EfUserRoleDal>();
            services.AddScoped<IBookDal, EfBookDal>();
            services.AddScoped<IAuthorDal, EfAuthorDal>();
            services.AddScoped<IRentedBookDal, EfRentedBookDal>();



            return services;
        }
    }
}
