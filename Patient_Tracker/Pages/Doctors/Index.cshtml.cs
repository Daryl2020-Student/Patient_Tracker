namespace Patient_Tracker.Pages.Doctors
{
    public class IndexModel : PageModel
    {
        private readonly Patient_Tracker.Data.Patient_Tracker_Context _context;

        public IndexModel(Patient_Tracker.Data.Patient_Tracker_Context context)
        {
            _context = context;
        }

        public IList<Doctor> Doctors { get; set; } = default!;

        // GET handler for the index page
        public async Task OnGetAsync()
        {
            if (_context.Doctors != null)
            {
                Doctors = await _context.Doctors.ToListAsync(); // Retrieve the list of doctors from the context and assign it to the Doctor property
            }
        }
    }
}
