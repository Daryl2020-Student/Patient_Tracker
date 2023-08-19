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

        
          

                var doctor= _context.Doctors.FirstOrDefault(d => d.Password == Doctor.Password);

                var checkBeans = Beans(Doctor.Email);

                if (checkBeans != doctor.Email && checkBeans == null)
                {
                    // Doctor not found
                    ModelState.AddModelError(string.Empty, "Invalid email or password.");
                    return Page();
                }

                if (doctor.Password != Doctor.Password && Doctor.Password == null)
                {
                    // Invalid password
                    ModelState.AddModelError(string.Empty, "Invalid email or password.");
                    return Page();
                }
            

            // Successful login
            ShowNavbar = true; // Show the navbar

            // Redirect to another page
            return RedirectToPage("/Patients/Index");
        }

        private string Beans(string beans)
        {
            return beans.ToUpper();
        }
    }
}
