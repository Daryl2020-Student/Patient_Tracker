using Patient_Tracker.Services;

namespace Patient_Tracker.Pages.Doctors
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
        public Doctor Doctor { get; set; } = new Doctor();

        public async Task<IActionResult> OnPostAsync()
        {
            var AddVal = await GetEircodeAsync(Doctor.Address);

            Doctor.Address = AddVal;

            if (!ModelState.IsValid || _context.Doctors == null || Doctor == null)
            {
                return Page();
            }

            var test = await Convert(Doctor);

            // Check if a doctor with the same email already exists
            bool doctorExists = await _context.Doctors.AnyAsync(d => d.Email == test.Email);
            if (doctorExists)
            {
                ModelState.AddModelError("Doctor.Email", "A doctor with the same email already exists.");
                return Page();
            }

            // Check if a doctor with the same madical licence number already exists
            bool licenceExists = await _context.Doctors.AnyAsync(d => d.LicenceNumber == test.LicenceNumber);
            if (doctorExists)
            {
                ModelState.AddModelError("Doctor.Licence", "A doctor with the same licence number already exists.");
                return Page();
            }

            _context.Doctors.Add(test);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
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
