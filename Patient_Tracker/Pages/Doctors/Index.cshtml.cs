namespace Patient_Tracker.Pages.Doctors
{
    public class IndexModel : PageModel
    {
        private readonly Patient_Tracker.Data.Patient_Tracker_Context _context;

        public IndexModel(Patient_Tracker.Data.Patient_Tracker_Context context)
        {
            _context = context;
        }

        public string? FindFilter;

        public IList<Doctor> Doctors { get; set; } = default!;

        public async Task OnGetAsync(string searchString)
        {
            FindFilter = searchString;

            if (!string.IsNullOrEmpty(searchString))
            {
                var list = _context.Doctors.Where(s => s.LicenceNumber.Contains(searchString) || (s.DFirstName.Contains(searchString) || (s.DLastName.Contains(searchString))));
                Doctors = await list.ToListAsync();
            }
            else
            {
                Doctors = await _context.Doctors.ToListAsync(); // Retrieve the list of doctors from the context and assign it to the Doctor property
            }
        }
    }
}
