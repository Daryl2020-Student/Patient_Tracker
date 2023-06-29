namespace Patient_Tracker.Pages.Doctors
{
    public class DeleteModel : PageModel
    {
        private readonly Patient_Tracker_Context _context;

        public DeleteModel(Patient_Tracker_Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Doctor Doctor { get; set; } = default!;

        // GET handler for the delete confirmation page
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Doctors == null)
            {
                return NotFound(); // If the id or context is null, return a not found page
            }

            var doctor = await _context.Doctors.FirstOrDefaultAsync(m => m.Id == id);

            if (doctor == null)
            {
                return NotFound(); // If the doctor is not found, return a not found page
            }
            else
            {
                Doctor = doctor; // Set the Doctor property to the found doctor
            }

            return Page();
        }

        // POST handler for the delete confirmation form
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Doctors == null)
            {
                return NotFound(); // If the id or context is null, return a not found page
            }

            var doctor = await _context.Doctors.FindAsync(id);

            if (doctor != null)
            {
                Doctor = doctor; // Set the Doctor property to the found doctor
                _context.Doctors.Remove(Doctor); // Remove the doctor from the context
                await _context.SaveChangesAsync(); // Save changes to the database
            }

            return RedirectToPage("./Index"); // Redirect to the index page after successful deletion
        }
    }
}
