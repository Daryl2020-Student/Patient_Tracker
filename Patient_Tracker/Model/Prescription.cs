namespace Patient_Tracker.Model
{
    public class Prescription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int PrescriptionID { get; set; }

        [DisplayName("PPS Number")]
        public string PrescriptionPPS { get; set; }

        [DisplayName("Name")]
        public string? PatientsName { get; set; }

        [DisplayName("Medication")]
        public string Medication { get; set; }

        [DisplayName("Dosage")]
        public string Dosage { get; set; }

        [DisplayName("Quantity")]
        public string Quantity { get; set; }

        [DisplayName("Date")]
        public DateOnly Date { get; set; }

        [DisplayName("Time")]
        public TimeOnly Time { get; set; }

        [DisplayName("Doctor")]
        public string Doctor { get; set; }

        [DisplayName("Notes")]
        public string Notes { get; set; }
    }
}
