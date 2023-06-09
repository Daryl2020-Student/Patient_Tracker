using Microsoft.EntityFrameworkCore;
using Patient_Tracker.Model;

namespace Patient_Tracker.Data
{
    // Patient_Tracker_Context is the database context for the Patient Tracker application.
    public class Patient_Tracker_Context : DbContext
    {   
        // Constructor that accepts the DbContextOptions to configure the database connection.
        public Patient_Tracker_Context(DbContextOptions<Patient_Tracker_Context> options) : base(options) { }

        // DbSet representing the collection of doctors in the database.
        public DbSet<Doctor> Doctors { get; set; } = default!;

        // DbSet representing the collection of patients in the database.
        public DbSet<Patient> Patients { get; set; } = default!;
    }
}
