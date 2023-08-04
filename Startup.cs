using System.Reflection;
using CartService.Interfaces;
using CartService.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CartService
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Регистрация MediatR и указание, что обработчики запросов и команд находятся в текущей сборке
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddScoped<ICartRepository, CartRepository>(); 
            services.AddScoped<Services.CartService>();

            services.AddControllers();
            //services.AddDbContext<ApiContext>(o => o.UseInMemoryDatabase(databaseName: "TrueCodeDb"));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            // Добавление обработчика ошибок и установка заголовков CORS
            app.UseExceptionHandler("/error");
            app.UseCors();

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}