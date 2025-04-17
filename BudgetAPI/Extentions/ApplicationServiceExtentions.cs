using System;
using System.Reflection.Metadata.Ecma335;
using BudgetAPI.Data;
using BudgetAPI.Data.Repositories;
using BudgetAPI.Interfaces;
using BudgetAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace BudgetAPI.Extentions;

public static class ApplicationServiceExtentions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,
        IConfiguration config)
    {
        services.AddControllers();
        services.AddDbContext<DataContext>(opt =>
        {
            opt.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        });
        services.AddCors();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ILedgerRepository, LedgerRepository>();

        return services;
    }
}
