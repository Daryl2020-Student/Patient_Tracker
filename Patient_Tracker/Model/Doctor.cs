namespace Patient_Tracker.Model
{
    // Doctor class represents a doctor entity.
    public class Doctor
    {
        // Id of the doctor.
        public int Id { get; set; }

        // First name of the doctor.
        public string DFirstName { get; set; }

        // Last name of the doctor.
        public string DLastName { get; set; }

        // Email address of the doctor.
        public string Email { get; set; }

        // Address of the doctor.
        public string Address { get; set; }
    }
}
