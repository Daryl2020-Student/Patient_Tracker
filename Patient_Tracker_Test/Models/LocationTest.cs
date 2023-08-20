using Patient_Tracker.Model;

namespace Patient_Tracker_Test.Models 
{
    public class LocationTest //Creating a class for testing the Location model
    {
        [Fact]
        public void LocLocationModelTest() //Testing the Location model
        {
            Location loc = new(); //Creating a new instance of the Location class

            // Arrange
            loc.lat = 53.3498; //Assigning a latitude value to the location object
            loc.lng = 6.2603; //Assigning a longitude value to the location object

            // Act
            var result = loc; //Calling the Location object

            // Assert
            Assert.Equal(53.3498, result.lat); //Checking that the latitude value is correct
            Assert.Equal(6.2603, result.lng); //Checking that the longitude value is correct       
        }
    }
}
