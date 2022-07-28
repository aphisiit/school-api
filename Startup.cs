using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SchoolAPI.Contexts;
using SchoolAPI.Models;
using SchoolAPI.Services;
using SchoolAPI.Services.Implements;

namespace SchoolAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public delegate IMathService ServiceResolver(string key);

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddScoped<IPersonService<Student>, StudentService>();

            services.AddTransient<CircleService>();
            services.AddTransient<SquareService>();

            services.AddTransient<ServiceResolver>(serviceProvider => key =>
            {
                switch (key)
                {
                    case "Circle":
                        return serviceProvider.GetService<CircleService>();
                    case "Square":
                        return serviceProvider.GetService<SquareService>();
                    default:
                        throw new KeyNotFoundException();
                }
            });
            var conStr = Configuration.GetConnectionString("Postgresql");
            services.AddDbContext<TrainingContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("Postgresql"));
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SimpleDotNET5", Version = "v1" });
            });

            services.AddHealthChecks();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SimpleDotNET5 v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });
        }
    }
}

