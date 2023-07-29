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

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public SelectList? Gender { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? PatientGender { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> genderQuery = from p in _context.Patients
                                          orderby p.Gender
                                          select p.Gender;

            var patients = from p in _context.Patients
                           select p;
            if (!string.IsNullOrEmpty(SearchString))
            {
                patients = patients.Where(s => s.PPSNo.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(PatientGender))
            {
                patients = patients.Where(x => x.Gender == PatientGender);
            }

            Gender = new SelectList(await genderQuery.Distinct().ToListAsync());
            Patient = await patients.ToListAsync();

            if (_context.Patients != null)
            {
                Patient = await _context.Patients.ToListAsync();
            }
        }
    }
}
