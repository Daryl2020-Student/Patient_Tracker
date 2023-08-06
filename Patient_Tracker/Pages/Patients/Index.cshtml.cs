namespace Patient_Tracker.Pages.Patients
{
    public class IndexModel : PageModel
    {
        private readonly Patient_Tracker_Context _context;

        public IndexModel(Patient_Tracker_Context context)
        {
            _context = context;
        }

        public string? FindFilter;

        public IList<Patient> Patient { get; set; } = default!;

        public async Task OnGetAsync(string searchString)
        {
            FindFilter = searchString;
            
            if (!string.IsNullOrEmpty(searchString))
            {
                var list = _context.Patients.Where(s => s.PPSNo.Contains(searchString) || (s.FirstName.Contains(searchString) || (s.LastName.Contains(searchString))));
                Patient = await list.ToListAsync();
            }
            else
            {
                Patient = await _context.Patients.ToListAsync();
            }
        }
    }
}
