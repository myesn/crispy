using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Crispy.AdminApi.Host
{
    public class Startup
    {
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AdminApiOptions>(Configuration.GetSection(nameof(AdminApiOptions)));

            services
                .AddMvcCore(options =>
                {
                    options.Filters.Add<ModelStateFilter>();
                    options.Filters.Add<AutomaticExceptionFilter>();
                })
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                })
                .AddDataAnnotations()
                .AddApiExplorer()
                .AddCors(options =>
                {
                    options.AddPolicy("allowany", policy =>
                    {
                        policy.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowCredentials()
                        .AllowAnyMethod();
                    });
                });

            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            var migrationAssemblyName = typeof(Startup).Namespace;

            services
                .AddCrispyEntityFrameworkAuto(connectionString, migrationAssemblyName)
                .AddCrispyServices();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "crispy admin api", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseCors("allowany");

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.DocExpansion(DocExpansion.None);
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "crispy admin api");
            });

            app.UseMvcWithDefaultRoute();

        }
    }
}
