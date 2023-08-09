namespace Patient_Tracker.Services
{
    public class APIs
    {
        [ApiController]
        [Route("api/[patients]")]
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

            [HttpPost]
            public async Task<IActionResult> CreatePatient([FromBody] Patient patient)
            {
                if (patient == null)
                {
                    return BadRequest();
                }

                var check = CheckPPS();
                if (check.Contains(patient.PPSNo))
                {
                    return Conflict("This PPS Number is already registered");
                }

                _context.Patients.Add(patient);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetPatient), new { id = patient.Id }, patient);
            }

            private List<string> CheckPPS()
            {
                List<string> ppsList = new List<string>();
                foreach (var item in _context.Patients)
                {
                    ppsList.Add(item.PPSNo);
                }
                return ppsList;
            }
        }
    }
}
