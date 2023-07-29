namespace Patient_Tracker.Pages.Doctors
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
        public Doctor Doctor { get; set; } = new Doctor();

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Doctors == null || Doctor == null)
            {
                return Page();
            }

            // Check if a doctor with the same email already exists
            bool doctorExists = await _context.Doctors.AnyAsync(d => d.Email == Doctor.Email);
            if (doctorExists)
            {
                ModelState.AddModelError("Doctor.Email", "A doctor with the same email already exists.");
                return Page();
            }

            // Check if a doctor with the same madical licence number already exists
            bool licenceExists = await _context.Doctors.AnyAsync(d => d.LicenceNumber == Doctor.LicenceNumber);
            if (doctorExists)
            {
                ModelState.AddModelError("Doctor.Licence", "A doctor with the same licence number already exists.");
                return Page();
            }

            _context.Doctors.Add(Doctor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
