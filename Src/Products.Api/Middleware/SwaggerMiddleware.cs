using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Products.Api.Filters;
using Swashbuckle.AspNetCore.Swagger;

namespace Products.Api.Middleware
{
    public static class SwaggerMiddleware
    {
        /// <summary>
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "Ireckonu products Api",
                    Version = "1.0.0.0",
                    Description = "products processing via file uploader.",
                    Contact = new Contact
                    {
                        Name = "Ireckonu Lmt.",
                        Email = "Remco@ireckonu.com",
                        Url = "http://www.ireckonu.com"
                    }
                });
                c.OperationFilter<AuthorizationHeaderParameterOperationFilter>(); //apply swagger on apis.
                c.CustomSchemaIds(x => x.FullName);
            });
        }

        /// <summary>
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="useSwagger"></param>
        public static void ConfigureSwagger(this IApplicationBuilder app, IHostingEnvironment env, bool useSwagger)
        {
            if (!env.IsDevelopment() && !useSwagger) return;

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ireckonu Products API V1");
            });
        }
    }
}
