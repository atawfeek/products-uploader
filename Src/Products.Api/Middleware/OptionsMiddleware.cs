using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Products.Dto.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Api.Middleware
{
    public static class OptionsMiddleware
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <param name="keyVaultClient"></param>
        /// <param name="azureMsiOptions"></param>
        public static void ConfigureOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ApplicationSettingsOptions>(options =>
            {
                configuration.GetSection(StaticData.ApplicationSettings).Bind(options);
            });
        }
    }
}
