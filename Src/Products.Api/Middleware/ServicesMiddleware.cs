using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Products.Api.AutoMapper;
using Products.Dto.Options;
using Products.Service.Data;
using Products.Service.Interfaces;
using Products.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Api.Middleware
{
    public static class ServicesMiddleware
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <param name="keyVaultClient"></param>
        /// <param name="azureServiceTokenProvider"></param>
        /// <param name="azureMsiOptions"></param>
        /// <param name="azureStorageOptions"></param>
        /// <param name="azureServiceBusOptions"></param>
        /// <param name="appOptions"></param>
        public static void ConfigureServices(this IServiceCollection services,
                                                IConfiguration configuration,
                                                ApplicationSettingsOptions appOptions)
        {
            // To list physical files from a path provided by configuration:
            var physicalProvider = new PhysicalFileProvider(configuration.GetValue<string>("ApplicationSettings:StoredFilesPath"));
            services.AddSingleton<IFileProvider>(physicalProvider);

            var sqlDefaultConnection = string.Empty;

            // Uses Sql Authentication - ** Production usage for  real db instead of InMemory.
            sqlDefaultConnection = string.IsNullOrEmpty(appOptions.SqlConnectionString) ?
                                        "connection string is missing." : appOptions.SqlConnectionString;

            //register db context in memory
            services.AddDbContext<ProductsDbContext>(options => options.UseInMemoryDatabase("InMemoryProductsDb"));

            //register services
            services.AddScoped<IProductService, ProductService>();

            //register automapper
            services.AddSingleton(provider => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfileConfiguration());
            }).CreateMapper());
        }
    }
}
