using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hw_middleware_api_16_5_22
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "hw_middleware_api_16_5_22", Version = "v1" });
            });
            services.AddTransient<StudentClassMiddleware>();
            services.AddTransient<studentmiddleware>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "hw_middleware_api_16_5_22 v1"));
            }
          
            app.Map("/student/5", HandleStudentsFiveRoute);
            app.UseMiddleware<StudentClassMiddleware>();
            app.UseMiddleware<studentmiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
        }

        private void HandleStudentsFiveRoute(IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                string student = context.Request.Path.Value.Split("/")[1];
                await context.Response.WriteAsync($"hello from class 5 this is a spaciel class\n");
                await context.Response.WriteAsync($"hello from student {student}\n ");
        
            });


       
        }
    }
}
