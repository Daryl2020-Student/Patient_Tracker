using Patient_Tracker.Model;

namespace Patient_Tracker_Test.Model
{
    public class PrescriptionTests
    {
        [Fact]
        public void PrescriptionID_SetAndGet_Success()
        {
            //New Test
            // Arrange
            var prescription_id = new Prescription();
            var expectedPrescriptionID = 1800696969;

            // Act
            prescription_id.PrescriptionID = expectedPrescriptionID;
            var retrievedPrescriptionID = prescription_id.PrescriptionID;

            //New Test
            // Arrange
            var prescription_name = new Prescription();
            var expectedPatientsName = "Beans";

            // Act
            prescription_name.PatientsName = expectedPatientsName;
            var retrievedPatientsName = prescription_name.PatientsName;

            //New Test
            // Arrange
            var prescription_medication = new Prescription();
            var expectedMedication = "Beans2";

            // Act
            prescription_medication.Medication = expectedMedication;
            var retrievedMedication = prescription_medication.Medication;

            //New Test
            // Arrange
            var prescription_dosage = new Prescription();
            var expectedDosage = "Lots of beans";

            // Act
            prescription_dosage.Dosage = expectedDosage;
            var retrievedDosage = prescription_dosage.Dosage;

            //New Test
            // Arrange
            var prescription_quantity = new Prescription();
            var expectedQuantity = "Even more beans";

            // Act
            prescription_quantity.Quantity = expectedQuantity;
            var retrievedQuantity = prescription_quantity.Quantity;

            //New Test
            // Arrange
            var prescription_doctor = new Prescription();
            var expectedDoctor = "Dr.Beans";

            // Act
            prescription_doctor.Doctor = expectedDoctor;
            var retrievedDoctor = prescription_doctor.Doctor;

            //New Test
            // Arrange
            var prescription_notes = new Prescription();
            var expectedNotes = "Take heaps of beans";

            // Act
            prescription_notes.Notes = expectedNotes;
            var retrievedNotes = prescription_notes.Notes;

            // Assert
            Assert.Equal(expectedPatientsName, retrievedPatientsName);
            Assert.Equal(expectedPrescriptionID, retrievedPrescriptionID);
            Assert.Equal(expectedMedication, retrievedMedication);
            Assert.Equal(expectedDosage, retrievedDosage);
            Assert.Equal(expectedQuantity, retrievedQuantity);
            Assert.Equal(expectedDoctor, retrievedDoctor);
            Assert.Equal(expectedNotes, retrievedNotes);
        }
    }
}

