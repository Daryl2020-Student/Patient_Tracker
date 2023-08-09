namespace Patient_Tracker.Services
{
    public class APIs
    {
        [ApiController]
        [Route("api/[controller]")]
        public class PatientsController : ControllerBase
        {
            private readonly Patient_Tracker_Context _context;

            public PatientsController(Patient_Tracker_Context context)
            {
                _context = context;
            }

            [HttpGet]
            public async Task<IActionResult> GetPatients()
            {
                var patients = await _context.Patients.ToListAsync();
                return Ok(patients);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetPatient(int id)
            {
                var patient = await _context.Patients.FindAsync(id);
                if (patient == null)
                {
                    return NotFound();
                }

                return Ok(patient);
            }
        }
    }
}

