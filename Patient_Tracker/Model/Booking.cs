namespace Patient_Tracker.Model
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingID { get; set; }

        [DisplayName("Name")]
        public string? BookingName { get; set; }

        [DisplayName("PPS")]
        public string BookingPPS { get; set; }

        [DisplayName("Date")]
        public DateOnly BookingDate { get; set; }

        [DisplayName("Time")]
        public TimeOnly BookingTime { get; set; }
    }
}
