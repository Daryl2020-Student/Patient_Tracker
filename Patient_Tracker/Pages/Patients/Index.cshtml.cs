namespace Patient_Tracker.Pages.Patients
{
    public class IndexModel : PageModel
    {
        private readonly Patient_Tracker_Context _context;

        public IndexModel(Patient_Tracker_Context context)
        {
            _context = context;
        }



        public string? ppsFilter;


        public IList<Patient> Patient { get; set; } = default!;

        public async Task OnGetAsync(string searchString)
        {
            ppsFilter = searchString;
            
            if (!string.IsNullOrEmpty(searchString))
            {
                var list = _context.Patients.Where(s => s.PPSNo.Contains(searchString));
                Patient = await list.ToListAsync();
            }
            else
            {
                Patient = await _context.Patients.ToListAsync();
            }
        }
    }
}
