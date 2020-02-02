using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Products.Api.AutoMapper;
using Products.Dto.Options;
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
