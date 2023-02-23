using Business.Abstract;
using Business.Concrete;
using Core.Security.JWT;
using Core.Utilities.JWT;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public static class BusinessServiceRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService,UserManager>();
            services.AddScoped<IAuthService, AuthManager>();
            services.AddScoped<IBookService, BookManager>();
            services.AddScoped<IAuthorService, AuthorManager>();
            services.AddScoped<IRentedBookService, RentedBookManager>();
            services.AddTransient<ITokenHelper, JwtHelper>();

            return services;
        }
    }
}
