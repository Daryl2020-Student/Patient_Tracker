using System.ComponentModel;

namespace Patient_Tracker.Model
{
    public class Doctor
    {
        // Primary key
        public int Id { get; set; }

        // First name of the doctor.
        [DisplayName("First Name")]
        public string DFirstName { get; set; }

        // Last name of the doctor.
        [DisplayName("Last Name")]
        public string DLastName { get; set; }

        // Address of the doctor.
        public string Address { get; set; }

        // Email of the doctor.
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        // Password of the doctor.
        public string Password { get; set; }

        //Doctors medical licence number
        [DisplayName("Licence Number")]
        [StringLength(8)]
        public string LicenceNumber { get; set; }
    }
}
