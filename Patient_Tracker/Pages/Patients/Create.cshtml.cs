using Patient_Tracker.Services;

namespace Patient_Tracker.Pages.Patients
{
    public class CreateModel : PageModel
    {
        private readonly Patient_Tracker_Context _context;

        private readonly AddressService _addressService = new();

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
            var AddVal = await GetEircodeAsync(Patient.Address);

            Patient.Address = AddVal;

            var check = CheckPPS();
            if (check.Contains(Patient.PPSNo))
            {
                ModelState.AddModelError(string.Empty, "This PPS Number is already registered");
                return Page();
            }
            
            // update all strings in object to upper
            foreach (var prop in Patient.GetType().GetProperties())
            {
                if (prop.PropertyType == typeof(string))
                {
                    var value = (string)prop.GetValue(Patient);
                    if (value != null)
                    {
                        prop.SetValue(Patient, value.ToUpper());
                    }
                }
            }

            _context.Patients.Add(Patient);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");            
        }

        private List<string> CheckPPS()
        {
            List<string> ppsList = new();
            foreach (var item in _context.Patients)
            {
                ppsList.Add(item.PPSNo);
            }
            return ppsList;
        }

        private async Task<string> GetEircodeAsync(string eir)
        {
            string eircode = "";

            var getEircode = await _addressService.GetAddress(eir);

            foreach (var item in getEircode)
            {
                {
                eircode = item.formatted_address;
            }
            }
            return eircode;
        }
    }
}
