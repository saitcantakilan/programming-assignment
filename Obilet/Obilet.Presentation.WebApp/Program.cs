using FluentValidation.AspNetCore;
using Obilet.Core;
using Obilet.Infrastructure;
using Obilet.Presentation.WebApp.Exceptions;
using Obilet.Presentation.WebApp.Extensions;
using Obilet.Presentation.WebApp.Validations;
using System.Reflection;
namespace Obilet.Presentation.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddHttpContextAccessor();

            // Add extensions to the container.
            builder.Services.AddExceptionHandlerExtensions();


            // Add services to the container.
            builder.Services.AddCoreConfigureService(builder.Configuration);
            builder.Services.AddInfrastructureService(builder.Configuration);
            builder.Services.AddControllersWithViews();

            builder.Services.AddLogging(config =>
            {
                config.AddConsole();
                config.AddDebug();
            });

            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler(_ => { });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
