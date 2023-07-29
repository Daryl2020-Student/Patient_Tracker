namespace Patient_Tracker.Pages.Patients
{
    public class IndexModel : PageModel
    {
        private readonly Patient_Tracker.Data.Patient_Tracker_Context _context;

        public IndexModel(Patient_Tracker.Data.Patient_Tracker_Context context)
        {
            _context = context;
        }

        public IList<Patient> Patient { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Patients != null)
            {
                Patient = await _context.Patients.ToListAsync();
            }
        }
    }
}
