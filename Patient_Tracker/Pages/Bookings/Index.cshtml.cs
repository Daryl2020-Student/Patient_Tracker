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
                searchString = searchString.ToUpper();

                Booking = await Convert();
                var list = _context.Bookings.Where(s => s.BookingPPS.Contains(searchString) || 
                (s.BookingName.Contains(searchString)));
                Booking = await list.ToListAsync();
            }
            else
            {
                Booking = await Convert();
            }
        }

        //change all strings to lowercase in Patients object
        private Task<List<Booking>> Convert()
        {
            var list = _context.Bookings.ToListAsync();
            foreach (var booking in list.Result)
            {
                booking.BookingPPS = FirstCharToUpper(booking.BookingPPS);
                booking.BookingName = FirstCharToUpper(booking.BookingName);
            }
            return list;
        }

        //first character of string to uppercase
        private string FirstCharToUpper(string input)
        {
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            return textInfo.ToTitleCase(input.ToLower());
        }
    }
}
