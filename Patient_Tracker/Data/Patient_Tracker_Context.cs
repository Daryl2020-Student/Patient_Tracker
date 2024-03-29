﻿namespace Patient_Tracker.Data
{
    // Patient_Tracker_Context is the database context for the Patient Tracker application.
    public class Patient_Tracker_Context : DbContext
    {
        // Constructor that accepts the DbContextOptions to configure the database connection.
        public Patient_Tracker_Context(DbContextOptions<Patient_Tracker_Context> options) : base(options) { }


        public Patient_Tracker_Context() { } // Parameterless constructor}
        // DbSet representing the collection of doctors in the database.

        public DbSet<Doctor> Doctors { get; set; }

        // DbSet representing the collection of patients in the database.
        public DbSet<Patient> Patients { get; set; }

        // DbSet representing the collection of patients in the database.
        public DbSet<Patient_Tracker.Model.Booking> Bookings { get; set; } = default!;

        // DbSet representing the collection of patients in the database.
        public DbSet<Patient_Tracker.Model.Prescription> Prescription { get; set; } = default!;

    }
}
