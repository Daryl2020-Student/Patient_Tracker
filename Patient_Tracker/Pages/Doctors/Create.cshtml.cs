using Patient_Tracker.Services;

namespace Patient_Tracker.Pages.Doctors
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
        public Doctor Doctor { get; set; } = new Doctor();

        [BindProperty]
        public string Building { get; set; }

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
            if (!string.IsNullOrEmpty(Building) && !string.IsNullOrEmpty(Street) && !string.IsNullOrEmpty(Town) && !string.IsNullOrEmpty(City))
            {
                Doctor.Address = Building + "," + Street + "," + Town + "," + City;
            }
            else
            {
                var AddAddress = await GetEircodeAsync(Doctor.Address);
                Doctor.Address = AddAddress;
            }

            if (!string.IsNullOrEmpty(Eir))
            {
                Doctor.Address = Eir;
            }
            else
            {
                var AddAddress = await GetAddressAsync(Doctor.Address);
                Doctor.Address = AddAddress;
            }

            var check1 = CheckLicence();
            if (check1.Contains(Doctor.LicenceNumber))
            {
                ModelState.AddModelError(string.Empty, "This Licence Number is already registered");
                return Page();
            }

            var check2 = CheckEmail();
            if (check2.Contains(Doctor.Email))
            {
                ModelState.AddModelError(string.Empty, "This Email is already registered");
                return Page();
            }

            var convert = await Convert(Doctor);          

            _context.Doctors.Add(Doctor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private List<string> CheckLicence()
        {
            List<string> licenceList = new();
            foreach (var item in _context.Doctors)
            {
                licenceList.Add(item.LicenceNumber);
            }
            return licenceList;
        }

        private List<string> CheckEmail()
        {
            List<string> emailList = new();
            foreach (var item in _context.Doctors)
            {
                emailList.Add(item.LicenceNumber);
            }
            return emailList;
        }

        //get address from eircode google maps api
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

        //get eircode from address google maps api
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

        //change all strings to lowercase in Doctors object
        private Task<Doctor> Convert(Doctor doctor)
        {
            doctor.DFirstName = CharToUpper(Doctor.DFirstName);
            doctor.DLastName = CharToUpper(Doctor.DLastName);
            doctor.Email = CharToUpper(Doctor.Email);
            doctor.LicenceNumber = CharToUpper(Doctor.LicenceNumber);
            doctor.Address = CharToUpper(Doctor.Address);
            doctor.Password = Doctor.Password;

            return Task.FromResult(doctor);
        }

        //first character of string to uppercase
        private static string CharToUpper(string input)
        {
       
            return input.ToUpper();
        }
    }
}
