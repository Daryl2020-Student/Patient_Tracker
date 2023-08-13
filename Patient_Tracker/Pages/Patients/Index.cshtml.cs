namespace Patient_Tracker.Pages.Patients
{
    public class IndexModel : PageModel
    {
        private readonly Patient_Tracker_Context _context;

        public IndexModel(Patient_Tracker_Context context)
        {
            _context = context;
        }

        public string? FindFilter;

        public IList<Patient> Patient { get; set; } = default!;

        public async Task OnGetAsync(string searchString)
        {
            FindFilter = searchString;

            if (!string.IsNullOrEmpty(searchString))
            {
                var list = _context.Patients.Where(s => s.PPSNo.Contains(searchString) || (s.FirstName.Contains(searchString) || (s.LastName.Contains(searchString))));
                Patient = await list.ToListAsync();
            }
            else
            {
               Patient = await Convert();
            }
        }

        //change all strings to lowercase in Patients object
        private Task<List<Patient>> Convert()
        {
            var list = _context.Patients.ToListAsync();
            foreach (var patient in list.Result)
            {
                patient.PPSNo = FirstCharToUpper( patient.PPSNo);
                patient.FirstName = FirstCharToUpper(patient.FirstName);
                patient.LastName = FirstCharToUpper(patient.LastName);
                patient.NextOfKin = FirstCharToUpper(patient.NextOfKin);
                patient.Gender = FirstCharToUpper(patient.Gender);
            }
            return list;
        }

        //first character of string to uppercase
        private string FirstCharToUpper(string input)
        {
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            return  textInfo.ToTitleCase(input.ToLower());
        }
    }
}
