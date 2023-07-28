using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Patient_Tracker.Data;
using Patient_Tracker.Model;

namespace Patient_Tracker.Pages.Patients
{
    public class IndexModel : PageModel
    {
        private readonly Patient_Tracker.Data.Patient_Tracker_Context _context;

        public IndexModel(Patient_Tracker.Data.Patient_Tracker_Context context)
        {
            _context = context;
        }

        public IList<Patient> Patient { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? PPSNum { get; set; }

        public async Task OnGetAsync()
        {
            var patients = from p in _context.Patients
                           select p;
            if (!string.IsNullOrEmpty(SearchString))
            {
                patients = patients.Where(s => s.PPSNo.Contains(SearchString));
            }

            if (_context.Patients != null)
            {
                Patient = await _context.Patients.ToListAsync();
            }
        }
    }
}
