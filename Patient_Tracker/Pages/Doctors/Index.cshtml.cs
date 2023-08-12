namespace Patient_Tracker.Pages.Doctors
{
    public class IndexModel : PageModel
    {
        private readonly Patient_Tracker.Data.Patient_Tracker_Context _context;

        public IndexModel(Patient_Tracker.Data.Patient_Tracker_Context context)
        {
            _context = context;
        }

        public string? FindFilter;

        public IList<Doctor> Doctors { get; set; } = default!;

        public async Task OnGetAsync(string searchString)
        {
            FindFilter = searchString;

            if (!string.IsNullOrEmpty(searchString))
            {
                var list = _context.Doctors.Where(s => s.LicenceNumber.Contains(searchString) || (s.DFirstName.Contains(searchString) || (s.DLastName.Contains(searchString))));
                Doctors = await list.ToListAsync();
            }
            else
            {
                Doctors = await Convert();
            }
        }

        //change all strings to lowercase in Patients object
        private Task<List<Doctor>> Convert()
        {
            var list = _context.Doctors.ToListAsync();
            foreach (var doctor in list.Result)
            {
                doctor.DFirstName = FirstCharToUpper(doctor.DFirstName);
                doctor.DLastName = FirstCharToUpper(doctor.DLastName);
                doctor.Email = FirstCharToUpper(doctor.Email);
            }
            return list;
        }

        //first character of string to uppercase
        private string FirstCharToUpper(string input)
        {
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            return textInfo.ToTitleCase(input.ToLower());
        }
    }
}
