using Garden.Infra.CrossCutting.IC;
using Garden.Infra.Data.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace Garden.Aplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy("Cors",
               builder =>
               {
                   builder.WithOrigins("http://localhost:3000",
                                       "http://localhost:3001")
                   .AllowAnyMethod()
                   .AllowAnyHeader();
               }));

            services.AddOptions();
            services.Configure<DataSettings>(Configuration.GetSection("ConnectionString"));

            services.AddRepositoryDependency();
            services.AddServiceDependency();
            services.AddSwaggerDependency();
            services.AddNotificationDependency();

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwaggerDependency();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseExceptionHandler(a => a.Run(async context =>
            {
                var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                var exception = exceptionHandlerPathFeature.Error;

                var result = JsonConvert.SerializeObject(new { error = exception.Message });
                context.Response.ContentType = "application/json";
                context.Response.Headers.Add("Access-Control-Allow-Origin", "*");

                await context.Response.WriteAsync(result);
            }));

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("Cors");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
