using Patient_Tracker.Services;

namespace Patient_Tracker.Pages.Patients
{
    public class CreateModel : PageModel
    {
        private readonly Patient_Tracker_Context _context;

        private readonly AddressService _addressService = new();

        private readonly EircodeService _eircodeService = new();

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

        [BindProperty]
        public string House { get; set; }

        [BindProperty]
        public string Street { get; set; }

        [BindProperty]
        public string Town { get; set; }

        [BindProperty]
        public string City { get; set; }

        [BindProperty]
        public string Eir { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!string.IsNullOrEmpty(House) && !string.IsNullOrEmpty(Street) && !string.IsNullOrEmpty(Town) && !string.IsNullOrEmpty(City))
            {
                Patient.Address = House + "," + Street + "," + Town + "," + City;
            }
            else
            {
                var AddAddress = await GetEircodeAsync(Patient.Address);
                Patient.Address = AddAddress;
            }

            if (!string.IsNullOrEmpty(Eir))
            {
                Patient.Address = Eir;
            }
            else
            {
                var AddAddress = await GetAddressAsync(Patient.Address);
                Patient.Address = AddAddress;
            }

            var check = CheckPPS();
            if (check.Contains(Patient.PPSNo))
            {
                ModelState.AddModelError(string.Empty, "This PPS Number is already registered");
                return Page();
            }

            await Convert(Patient);

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

        //get eircode from address
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

        //get address from eircode
        private async Task<string> GetAddressAsync(string add)
        {
            string address = "";

            var getAddress = await _eircodeService.GetEircode(add);

            foreach (var item in getAddress)
            {
                {
                    address = item.formatted_address;
                }
            }
            return address;
        }

        //change all strings to uppercase in Doctors object
        private Task<Patient> Convert(Patient patient)
        {
            patient.FirstName = CharToUpper(Patient.FirstName);
            patient.LastName = CharToUpper(Patient.LastName);
            patient.Address = CharToUpper(Patient.Address);
            patient.NextOfKin = CharToUpper(Patient.NextOfKin);
            patient.BloodType = CharToUpper(Patient.BloodType);
            patient.Gender = CharToUpper(Patient.Gender);
            patient.MedicalHistory = CharToUpper(Patient.MedicalHistory);
            return Task.FromResult(patient);
        }

        //first character of string to uppercase
        private static string CharToUpper(string input)
        {

            return input.ToUpper();
        }
    }
}
