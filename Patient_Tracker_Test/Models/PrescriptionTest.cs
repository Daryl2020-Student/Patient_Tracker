using Patient_Tracker.Model;

namespace Patient_Tracker_Test.Model
{
    public class PrescriptionTests
    {
        [Fact]
        public void PrescriptionID_SetAndGet_Success()
        {
            // Arrange
            var prescription_id = new Prescription();
            var PrescriptionID = 1800696969;

            // Act
            prescription_id.PrescriptionID = PrescriptionID;
            var retrievedPrescriptionID = prescription_id.PrescriptionID;

            // Arrange
            var prescription_name = new Prescription();
            var expectedPatientsName = "Beans";

            // Act
            prescription_name.PatientsName = expectedPatientsName;
            var retrievedPatientsName = prescription_name.PatientsName;

            

            // Assert
            Assert.Equal(expectedPatientsName, retrievedPatientsName);
            Assert.Equal(PrescriptionID, retrievedPrescriptionID);
        }

    }
}

