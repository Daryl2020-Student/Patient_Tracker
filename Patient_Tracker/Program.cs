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

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();
            app.MapControllers();

            app.Run();
        }
    }
}
