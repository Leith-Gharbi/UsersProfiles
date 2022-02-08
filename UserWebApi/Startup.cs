using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserWebApi.Models.DataBase;
using UserWebApi.Models.schedule;
using UserWebApi.Services;

namespace UserWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            //The Schedular Class
            SchedulerTask.StartAsync().GetAwaiter().GetResult();
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private readonly string _policyName = "CorsPolicy";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddDbContext<AppDbContext>(options => options.UseSqlite(Configuration.GetConnectionString("cs")));
            services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase(databaseName: "UsersDbControllerTest"));
            services.AddCors(opt =>
            {
                opt.AddPolicy(name: _policyName, builder =>
                {
                    builder
                    //.WithOrigins(new[] { "http://localhost:3000",
                    //    "http://localhost:8080",
                    //    "http://193.95.69.51:9001" })
                    .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        ;
                });
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "UserWebApi", Version = "v1" });
            });

            services.AddTransient<UserServices>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env , AppDbContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UserWebApi v1"));
            }
            try
            {
                db.Database.EnsureCreated();
                db.Database.Migrate();
            }
            catch (Exception)
            {

                //throw;
            }
           

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(_policyName);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
