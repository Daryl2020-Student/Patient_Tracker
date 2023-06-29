namespace Patient_Tracker.Model
{
    public class Doctor
    {
        // Primary key
        public int Id { get; set; }

        // First name of the doctor.
        public string DFirstName { get; set; }

        // Last name of the doctor.
        public string DLastName { get; set; }

        // Address of the doctor.
        public string Address { get; set; }

        // Email of the doctor.
        public string Email { get; set; }

        // Password of the doctor.
        public string Password { get; set; }
    }
}
