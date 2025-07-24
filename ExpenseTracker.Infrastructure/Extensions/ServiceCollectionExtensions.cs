using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.Domain.Repositories;
using ExpenseTracker.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ExpenseTracker.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions

    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration) {
            var ConnectionString = configuration.GetConnectionString("Db");
            services.AddDbContext<ExpenseTrackerDbContext>(Options=>Options.UseSqlServer(ConnectionString));

            services.AddScoped<ICategoryRepository,CategoryRepository>();
            services.AddScoped<IAccountRepository,AccountRepository>();
            services.AddScoped<IExpenseRepository,ExpenseRepository>();

            services.AddScoped<ITokenRepository, TokenRepository>();
            services.AddScoped<IPhotoService,PhotoService>();

        }
        
    }
}
