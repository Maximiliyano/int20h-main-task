using Microsoft.EntityFrameworkCore;
using WebAPI.Database;
using WebAPI.Extensions;

namespace WebAPI
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(
            IServiceCollection services)
        {
            var migrationAssembly = typeof(WebApiDbContext).Assembly.GetName().Name;
            services.AddDbContext<WebApiDbContext>(options =>
                options.UseSqlServer(_configuration.GetConnectionString("DbConnection"),
                    opt => opt.MigrationsAssembly(migrationAssembly)));
            
            services.RegisterCustomServices();

            services.AddControllers();
            services.AddSwaggerGen();
        }

        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseRouting();

            app.UseEndpoints(cfg =>
            {
                cfg.MapControllers();
            });
        }
    }
}