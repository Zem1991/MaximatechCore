﻿using Domain.Interfaces;
using Domain.Mappings;
using Domain.Services;
using Infrastructure.Context;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Api.Configurations
{
    public static class DependencyInjection
    {
        public static void AddInfrastructureApi(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(
                options => options.UseNpgsql(
                    connectionString, 
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
                    )
                );

            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddAutoMapper(typeof(DomainToDtoMappingProfile));
        }
    }
}