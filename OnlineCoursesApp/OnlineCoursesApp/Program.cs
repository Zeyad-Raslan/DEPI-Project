using Microsoft.EntityFrameworkCore;
using OnlineCoursesApp.BLL.Services;
using OnlineCoursesApp.DAL.Models;

namespace OnlineCoursesApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
      

            builder.Services.AddScoped<IService<Instructor>, Service<Instructor>>();
            builder.Services.AddScoped<IService<Course>, Service<Course>>();
            builder.Services.AddScoped<IService<Enroll>, Service<Enroll>>();
            builder.Services.AddScoped<IService<Section>, Service<Section>>();
            builder.Services.AddScoped<IService<Student>, Service<Student>>();



            builder.Services.AddDbContext<OnlineCoursesContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
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
