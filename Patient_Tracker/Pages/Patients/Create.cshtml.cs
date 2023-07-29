namespace Patient_Tracker.Pages.Patients
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
        public Patient Patient { get; set; } = new Patient();
        
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Patients == null || Patient == null)
            {
                return Page();
            }

            // Check if a patient with the same pps number already exists
            bool patientExists = await _context.Patients.AnyAsync(p => p.PPS == Patient.PPS);
            if (patientExists)
            {
                ModelState.AddModelError("Patient.PPS", "A patient with the same PPS number already exists.");
                return Page();
            }

            _context.Patients.Add(Patient);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
