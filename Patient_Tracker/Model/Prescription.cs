namespace Patient_Tracker.Model
{
    public class Prescription
    {
        [Key]
        public int PrescriptionID { get; set; }

        [DisplayName("PPS Number:")]
        public string PrescriptionPPS { get; set; }

        [DisplayName("Patients Name:")]
        public string? PatientsName { get; set; }

        [DisplayName("Medication")]
        public string Medication { get; set; }

        [DisplayName("Dosage")]
        public string Dosage { get; set; }

        [DisplayName("Quantity")]
        public string Quantity { get; set; }

        [DisplayName("Date")]
        public DateTime Date { get; set; }

        [DisplayName("Doctor")]
        public string Doctor { get; set; }

        [DisplayName("Notes")]
        public string Notes { get; set; }
    }
}
