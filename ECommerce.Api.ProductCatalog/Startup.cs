using AutoMapper;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ECommerce.Api.ProductCatalog.Aplication;
using ECommerce.Api.ProductCatalog.Persistence;

namespace ECommerce.Api.ProductCatalog
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<New>());

            services.AddDbContext<ContextProduct>(opt =>
            {
                opt.UseSqlServer(Configuration.GetConnectionString("ConectionDB"));
            });

            services.AddMediatR(typeof(New.Manejador).Assembly);
            services.AddAutoMapper(typeof(Query.Execute));
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            using (var scope = app.ApplicationServices.CreateScope())
            {
              ContextProduct context = scope.ServiceProvider.GetRequiredService<ContextProduct>();
              context.Database.Migrate();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseCors(options =>
              {
                options.WithOrigins("*");
                options.AllowAnyMethod();
                options.AllowAnyHeader();
              }
            );
        }
    }
}
