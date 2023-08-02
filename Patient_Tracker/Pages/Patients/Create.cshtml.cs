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
          if (_context.Patients == null || Patient == null)
            {
                return Page();
            }

            var check = CheckPPS();
            if (check.Contains(Patient.PPSNo))
            {
                ModelState.AddModelError(string.Empty, "This PPS Number is already registered");
                return Page();
            }

            _context.Patients.Add(Patient);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");

            //// Check if a patient with the same pps number already exists
            //bool patientExists = await _context.Patients.AnyAsync(p => p.PPSNo == Patient.PPSNo); 
            //if (patientExists)
            //{
            //    ModelState.AddModelError("Patient.PPS", "A patient with the same PPS number already exists.");
            //    return Page();
            //}

            //_context.Patients.Add(Patient);
            //await _context.SaveChangesAsync();

            //return RedirectToPage("./Index");
        }

        private List<string> CheckPPS()
        {
            List<string> emailList = new();
            foreach (var item in _context.Patients)
            {
                emailList.Add(item.PPSNo);
            }
            return emailList;
        }
    }
}
