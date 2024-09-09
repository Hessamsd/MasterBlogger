using Microsoft.EntityFrameworkCore;
using MB.Infrastructure.Core;
using Microsoft.Identity.Client;


namespace MB.Presentation.MVCCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.


           var connectionstring = builder.Configuration.GetConnectionString("MasterBloger");
           var wservices = builder.Services;
            BootStrapper.Config(wservices , connectionstring);




            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();
            app.MapDefaultControllerRoute();

            app.Run();
        }
    }
}
