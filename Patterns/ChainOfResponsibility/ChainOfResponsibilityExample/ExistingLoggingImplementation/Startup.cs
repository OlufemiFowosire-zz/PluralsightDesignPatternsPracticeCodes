using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExistingLoggingImplementation
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });

                endpoints.MapControllers();
            });

            app.Use(async (context, next) =>
            {
                Console.WriteLine("Handling #1");
                await next.Invoke();
                Console.WriteLine("Done #1");
            });

            app.Use(async (context, next) =>
            {
                Console.WriteLine("Handling #2");
                await next.Invoke();
                Console.WriteLine("Done #2");
            });

            app.Use(async (context, next) =>
            {
                Console.WriteLine("Handling #3");
                await next.Invoke();
                Console.WriteLine("Done #3");
            });
        }
    }
}
