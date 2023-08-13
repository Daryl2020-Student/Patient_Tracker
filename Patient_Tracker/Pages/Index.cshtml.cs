namespace Patient_Tracker.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Patient_Tracker_Context _context;

        [BindProperty]
        public Doctor Doctor { get; set; } = default!;

        public IndexModel(Patient_Tracker_Context context)
        {
            _context = context;
        }

        public bool ShowNavbar { get; set; }

        public IActionResult OnGet()
        {
            ShowNavbar = false;

            return Page();
        }

        public IActionResult OnPost()
        {

            if (Doctor.Email == string.Empty || Doctor.Password == string.Empty )
            {
                return Page();
            }

            // Find the doctor with the given email
   
            var doctorEmail = _context.Doctors.FirstOrDefault(d => d.Email == Doctor.Email);

            var doctorPassword = _context.Doctors.FirstOrDefault(d => d.Password == Doctor.Password);

            if (doctorEmail != null && doctorPassword!=null)
            {
                if (doctorEmail.Email != Doctor.Email)
                {
                    // Doctor not found
                    ModelState.AddModelError(string.Empty, "Invalid email or password.");
                    return Page();
                }

                if (doctorPassword.Password != Doctor.Password)
                {
                    // Invalid password
                    ModelState.AddModelError(string.Empty, "Invalid email or password.");
                    return Page();
                }
            }

            // Successful login
            ShowNavbar = true; // Show the navbar

            // Redirect to another page
            return RedirectToPage("/Patients/Index");
        }
    }
}
