namespace Patient_Tracker.Pages.Doctors
{
    public class DetailsModel : PageModel
    {
        private readonly Patient_Tracker.Data.Patient_Tracker_Context _context;

        public DetailsModel(Patient_Tracker.Data.Patient_Tracker_Context context)
        {
            _context = context;
        }

        public Doctor Doctor { get; set; } = default!;

        // GET handler for the details page
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound(); // If the id is null, return a not found page
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

            //Change all the doctor details to title case
            Doctor.DFirstName = ToTitleCase(Doctor.DFirstName);
            Doctor.DLastName = ToTitleCase(Doctor.DLastName);
            Doctor.Email = ToTitleCase(Doctor.Email);
            Doctor.Address = ToTitleCase(Doctor.Address);

            return Page();
        }

        //Change all the doctor details to title case
        public static string ToTitleCase(string str)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
        }
    }
}
