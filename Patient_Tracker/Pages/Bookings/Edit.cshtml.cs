namespace Patient_Tracker.Pages.Bookings
{
    public class EditModel : PageModel
    {
        private readonly Patient_Tracker.Data.Patient_Tracker_Context _context;

        public EditModel(Patient_Tracker.Data.Patient_Tracker_Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Booking Booking { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Bookings == null)
            {
                return NotFound();
            }

            var booking =  await _context.Bookings.FirstOrDefaultAsync(m => m.BookingID == id);
            if (booking == null)
            {
                return NotFound();
            }
            Booking = booking;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Booking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingExists(Booking.BookingID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BookingExists(int id)
        {
          return (_context.Bookings?.Any(e => e.BookingID == id)).GetValueOrDefault();
        }
    }
}
