namespace Patient_Tracker.Pages.Doctors
{
    public class EditModel : PageModel
    {
        private readonly Patient_Tracker.Data.Patient_Tracker_Context _context;

        public EditModel(Patient_Tracker.Data.Patient_Tracker_Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Doctor Doctor { get; set; } = default!;

        // GET handler for the edit page
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
            Doctor = doctor; // Set the Doctor property to the found doctor
            return Page();
        }

        // POST handler for the edit page
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // If the model state is not valid, return the page with validation errors
            }

            _context.Attach(Doctor).State = EntityState.Modified; // Attach the modified Doctor entity to the context

            try
            {
                await _context.SaveChangesAsync(); // Save the changes to the database
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoctorExists(Doctor.Id))
                {
                    return NotFound(); // If the doctor does not exist, return a not found page
                }
                else
                {
                    throw; // Throw an exception for other concurrency-related errors
                }
            }

            return RedirectToPage("./Index"); // Redirect to the index page after successful update
        }

        // Check if a doctor with the given ID exists in the database
        private bool DoctorExists(int id)
        {
            return (_context.Doctors?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
