namespace Patient_Tracker.Model
{
    // Patient class represents a patient entity.
    public class Patient
    {
        // Id of the patient.
        public int Id { get; set; }

        // First name of the patient.
        public string FirstName { get; set; }

        // Last name of the patient.
        public string LastName { get; set; }

        // Date of birth of the patient.
        public DateOnly DOB { get; set; }

        // Address of the patient.
        public string Address { get; set; }

        // Next of kin of the patient.
        public string NextOfKin { get; set; }
    }
}
