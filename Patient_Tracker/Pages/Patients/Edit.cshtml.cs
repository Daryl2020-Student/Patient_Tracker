using Patient_Tracker.Services;

namespace Patient_Tracker.Pages.Patients
{
    public class EditModel : PageModel
    {
        private readonly Patient_Tracker.Data.Patient_Tracker_Context _context;

        private readonly AddressService _addressService = new();

        public EditModel(Patient_Tracker.Data.Patient_Tracker_Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Patient Patient { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Patients == null)
            {
                return NotFound();
            }

            var patient = await _context.Patients.FirstOrDefaultAsync(p => p.Id == id);
            if (patient == null)
            {
                return NotFound();
            }
            Patient = patient;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var AddVal = await GetEircodeAsync(Patient.Address);

            Patient.Address = AddVal;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Patient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientExists(Patient.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PatientExists(int id)
        {
            return (_context.Patients?.Any(e => e.Id == id)).GetValueOrDefault();
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
