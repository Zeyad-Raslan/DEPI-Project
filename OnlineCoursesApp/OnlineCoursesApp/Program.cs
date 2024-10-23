using Microsoft.EntityFrameworkCore;
using OnlineCoursesApp.BLL.Services;
using OnlineCoursesApp.DAL.Models;
using OnlineCoursesApp.BLL.StudentService;
using Microsoft.AspNetCore.Identity;
using OnlineCoursesApp.BLL.AdminServices;
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
            builder.Services.AddScoped<IService<WebAdmin>, Service<WebAdmin>>();
            builder.Services.AddScoped<IService<StudentProgress>, Service<StudentProgress>>();

            builder.Services.AddScoped<IAdminComplexService, AdminComplexService>();
            builder.Services.AddScoped<IStudentComplexService, StudentComplexService>();

            // builder.Services.AddScoped()


            //var dbConnectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
            //    throw new InvalidOperationException("Missing connection string configuration");

            ////builder.Services.AddDbContext<IWBDbContext>(db => db.UseSqlServer(dbConnectionString));
            //builder.Services.AddDbContext<OnlineCoursesContext>(options =>
            //    options.UseSqlServer(dbConnectionString));

            // Inject UserManager (authentication)

            builder.Services.AddDbContext<OnlineCoursesContext>(options =>
              options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters = null;

                options.Password.RequiredUniqueChars = 0;
                options.Password.RequiredLength = 4;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
            })
            .AddEntityFrameworkStores<OnlineCoursesContext>()
            .AddRoles<IdentityRole>();

            //
//            builder.Services.AddIdentity<IdentityUser, IdentityRole>(
//options => {

//    options.User.RequireUniqueEmail = true;
//    options.User.AllowedUserNameCharacters = null;

//    options.Password.RequiredUniqueChars = 0;
//    options.Password.RequiredLength = 4;
//    options.Password.RequireUppercase = false;
//    options.Password.RequireNonAlphanumeric = false;
//    options.Password.RequireDigit = false;
//    options.Stores.MaxLengthForKeys = 128;
//})
//.AddEntityFrameworkStores<OnlineCoursesContext>()
//.AddRoles<IdentityRole>()
//.AddDefaultTokenProviders();
            //

            


            builder.Services.AddDistributedMemoryCache();

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(20);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");


            app.Run();
        }
    }
}
