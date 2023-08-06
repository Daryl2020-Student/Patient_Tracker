namespace Patient_Tracker.Pages.Bookings
{
    public class IndexModel : PageModel
    {
        private readonly Patient_Tracker.Data.Patient_Tracker_Context _context;

        public IndexModel(Patient_Tracker.Data.Patient_Tracker_Context context)
        {
            _context = context;
        }

        public string? FindFilter;

        public IList<Booking> Booking { get; set; } = default!;

        public async Task OnGetAsync(string searchString)
        {
            FindFilter = searchString;

            if (!string.IsNullOrEmpty(searchString))
            {
                var list = _context.Bookings.Where(s => s.BookingPPS.Contains(searchString) || (s.BookingName.Contains(searchString)));
                Booking = await list.ToListAsync();
            }
            else
            {
                Booking = await _context.Bookings.ToListAsync();
            }
        }
    }
}
