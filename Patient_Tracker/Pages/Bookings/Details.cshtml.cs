namespace Patient_Tracker.Pages.Bookings
{
    public class DetailsModel : PageModel
    {
        private readonly Patient_Tracker.Data.Patient_Tracker_Context _context;

        public DetailsModel(Patient_Tracker.Data.Patient_Tracker_Context context)
        {
            _context = context;
        }

      public Booking Booking { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Bookings == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings.FirstOrDefaultAsync(m => m.BookingID == id);
            if (booking == null)
            {
                return NotFound();
            }
            else 
            {
                Booking = booking;
            }

            Booking.BookingName = ToTitleCase(Booking.BookingName);

            return Page();
        }

        //Change all the doctor details to title case
        public static string ToTitleCase(string str)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
        }
    }
}
