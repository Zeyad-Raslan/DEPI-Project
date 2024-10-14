using Microsoft.EntityFrameworkCore;
<<<<<<< HEAD
using OnlineCoursesApp.BLL.AdminServices;
using OnlineCoursesApp.BLL.Services;
using OnlineCoursesApp.DAL.Models;

=======
using OnlineCoursesApp.BLL.Services;
using OnlineCoursesApp.DAL.Models;
using OnlineCoursesApp.BLL.AdminServices;
using OnlineCoursesApp.BLL.StudentService;
>>>>>>> 4392f2c2d6689bfe5ae3ea61d2782d6931c2ad6f
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
            builder.Services.AddScoped<IService<Section>, Service<Section>>();
            builder.Services.AddScoped<IService<Student>, Service<Student>>();
<<<<<<< HEAD
            builder.Services.AddScoped<IAdminComplexService, AdminComplexService>();
=======
            builder.Services.AddScoped<IService<StudentProgress>, Service<StudentProgress>>();

            builder.Services.AddScoped<IAdminComplexService, AdminComplexService>();
            builder.Services.AddScoped<IStudentComplexService, StudentComplexService>();
>>>>>>> 4392f2c2d6689bfe5ae3ea61d2782d6931c2ad6f



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
