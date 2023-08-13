using Microsoft.AspNetCore.Authentication.Cookies;

namespace Patient_Tracker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<Patient_Tracker_Context>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("Patient_Tracker_Context") ?? throw new InvalidOperationException("Connection string 'Patient_TrackerContext' not found.")));

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddControllers();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
                 {
                     options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                     options.SlidingExpiration = true;
                     options.AccessDeniedPath = "/Forbidden/";
                });

            // Configure the Patient_Tracker_Context to use SQLite as the database provider.
            builder.Services.AddDbContext<Patient_Tracker_Context>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString(nameof(Patient_Tracker_Context))));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorPages();
            app.MapDefaultControllerRoute();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();
            app.MapControllers();

            app.Run();
        }
    }
}
