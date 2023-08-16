using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Patient_Tracker.Pages.Prescriptions
{
    public class CreateModel : PageModel
    {
        private readonly Patient_Tracker_Context _context;

        public CreateModel(Patient_Tracker_Context context)
        {
            _context = context;
        }

        public Patient Patient { get; set; } = default!;

        [BindProperty]
        public Prescription Prescription { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Patients == null)
            {
                return NotFound();
            }

            var patient = await _context.Patients.FirstOrDefaultAsync(m => m.Id == id);

            if (patient == null)
            {
                return NotFound();
            }
            else
            {
                Patient = patient;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            var patient = await _context.Patients.FirstOrDefaultAsync(m => m.Id == id);

            Prescription.PatientsName = patient.FirstName + " " + patient.LastName;
            Prescription.PrescriptionPPS = patient.PPSNo;

            if (_context.Prescription == null || Prescription == null)
            {
                return Page();
            }

            _context.Prescription.Add(Prescription);
            await _context.SaveChangesAsync();

            using (MemoryStream memoryStream = new MemoryStream())
            {
                Document pdfDoc = new(PageSize.A4, 10f, 10f, 10f, 0f);

                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);

                pdfDoc.Open();
                pdfDoc.Add(new Paragraph("Date Prescribed: " + Prescription.Date.ToString("dddd, dd MMMM yyyy HH:mm:ss")));
                pdfDoc.Add(new Paragraph("PPS Nmber: " + Prescription.PrescriptionPPS));
                pdfDoc.Add(new Paragraph("Patients Name: " + Prescription.PatientsName));
                pdfDoc.Add(new Paragraph("Medication: " + Prescription.Medication));
                pdfDoc.Add(new Paragraph("Dosage: " + Prescription.Dosage));
                pdfDoc.Add(new Paragraph("Quantity: " + Prescription.Quantity));
                pdfDoc.Add(new Paragraph("Doctor: " +Prescription.Doctor));
                pdfDoc.Add(new Paragraph("Notes: " + Prescription.Notes));

                pdfDoc.Close();
                writer.Close();
                byte[] pdfBytes = memoryStream.ToArray();

                // Return the PDF as a FileStreamResult
                var stream = new MemoryStream(pdfBytes);
                return new FileStreamResult(stream, "application/pdf");
            }
        }
    }
}
