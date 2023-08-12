namespace Patient_Tracker.Pages.Patients
{
    public class DetailsModel : PageModel
    {
        private readonly Patient_Tracker.Data.Patient_Tracker_Context _context;

        public DetailsModel(Patient_Tracker.Data.Patient_Tracker_Context context)
        {
            _context = context;
        }

      public Patient Patient { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Patients == null)
            {
                return NotFound();
            }

            var patient = await _context.Patients.FirstOrDefaultAsync(m => m.Id == id);
            if (patient == null)
            {
                return NotFound();
            }

            else 
            {
                Patient = patient;
            }

            //Change all the patient details to title case
            Patient.FirstName = ToTitleCase(Patient.FirstName);
            Patient.LastName = ToTitleCase(Patient.LastName);
            Patient.NextOfKin = ToTitleCase(Patient.NextOfKin);
            Patient.Address = ToTitleCase(Patient.Address);
            Patient.Gender = ToTitleCase(Patient.Gender);

            return Page();
        }

        //Change all the patient details to title case
        public static string ToTitleCase(string str)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
        }
    }
}
