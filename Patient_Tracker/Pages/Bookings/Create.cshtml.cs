namespace Patient_Tracker.Pages.Bookings
{
    public class CreateModel : PageModel
    {
        private readonly Patient_Tracker_Context _context;

        public CreateModel(Patient_Tracker_Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Booking Booking { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            // Check if the model state is valid and the Booking and _context.Booking objects are not null
            if (!ModelState.IsValid || _context.Bookings == null || Booking == null)
            {
                return Page();
            }

            var checkPatient = CheckPatient();

            if (!checkPatient.Contains(Booking.BookingPPS))
            {
                ModelState.AddModelError(string.Empty, "You need to add the patient before adding an appointment");
                return Page();
            }

            // Check if the patient has too many bookings
            var ppsCount = _context.Bookings.FirstOrDefault(x => x.BookingPPS == Booking.BookingPPS && x.BookingDate == Booking.BookingDate);
            if (ppsCount is not null)
            {
                ModelState.AddModelError(string.Empty, "This Patient has a booking on this date");
                return Page();
            }

            // Check if the booking time slot is overbooked
            int overbooked = _context.Bookings.Count(x => x.BookingDate == Booking.BookingDate && x.BookingTime == Booking.BookingTime);
            if (overbooked == 1)
            {
                ModelState.AddModelError(string.Empty, "Too many patients have been booked this time");
                return Page();
            }

            var convert = await Convert(Booking);

            // Add the booking to the database and save changes
            _context.Bookings.Add(AddPatient());
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        /**
This method checks if the booking pps is registered in the patient database and returns a list of all pps numbers.
*/
        private string CheckPatient()
        {
            string patient = "";

            foreach (var item in _context.Patients)
            {
                patient += item.PPSNo + " ";
            }
            return patient;
        }
        private Booking AddPatient()
        {
            Booking patientList = new();

            foreach (var item in _context.Patients)
            {
                if (Booking.BookingPPS == item.PPSNo)
                {
                    patientList = new Booking
                    {
                        BookingPPS = item.PPSNo,
                        BookingName = item.FirstName + " " + item.LastName,
                        BookingDate = Booking.BookingDate,
                        BookingTime = Booking.BookingTime
                    };
                }
            }
            return patientList;
        }

        //change all strings to lowercase in Doctors object
        private Task<Booking> Convert(Booking booking)
        {
            booking.BookingPPS = CharToUpper(booking.BookingPPS);

            return Task.FromResult(booking);
        }

        //first character of string to uppercase
        private static string CharToUpper(string input)
        {
            return input.ToUpper();
        }
    }
}