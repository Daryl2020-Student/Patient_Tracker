using System.ComponentModel.DataAnnotations;

namespace Patient_Tracker.Model
{
    // Patient class represents a patient entity.
    public class Patient
    {
        // Id of the patient.
        public int Id { get; set; }

        // Id of the doctor licence number.
        public string DoctorName { get; set; }

        // First name of the patient.
        public string FirstName { get; set; }

        // Last name of the patient.
        public string LastName { get; set; }

        // Date of birth of the patient.
        [DataType(DataType.Date)]
        public DateOnly DOB { get; set; }

        // Address of the patient.
        public string Address { get; set; }

        // Next of kin of the patient.
        public string NextOfKin { get; set; }

        // Blood type of the patient.
        [RegularExpression(@"^(A|B|AB|O)[+-]$")]
        [StringLength(3)]
        [Required]
        public string BloodType { get; set; }

        // Gender of the patient.
        public string Gender { get; set; }

        //Medical history of the patient.
        public string MedicalHistory { get; set; }

        // Phone number of the patient.
        [DataType(DataType.PhoneNumber)]
        public int PhoneNumber { get; set; }

        //PPS number of the patient.
        [RegularExpression(@"^[a-zA-Z0-9\s]*$")]
        [Required]
        [StringLength(8)]
        public string PPSNo { get; set; }
    }
}
