using Patient_Tracker.Model;

namespace Patient_Tracker_Test.Models //Creating a namespace for the GeometryTest class
{
    public class Geometrytest //Creating a class for testing the Geometry model
    {
        [Fact]
        public void GeometryModel() //Testing the Geometry model
        {
            // Arrange
            Geometry geo = new() //Creating a new instance of the Geometry class
            {
                // Act
                location = new Location //Creating a new instance of the Location class
                {
                    lat = 50.0, //Assigning a latitude value to the location object
                    lng = -50.0 //Assigning a longitude value to the location object
                },
                location_type = "test" //Assigning a location type to the Geometry object
            };

            // Assert
            Assert.NotNull(geo); //Checking that the Geometry object is not null
            Assert.NotNull(geo.location); //Checking that the location object is not null
            Assert.Equal(50.0, geo.location.lat); //Checking that the latitude value is correct
            Assert.Equal(-50.0, geo.location.lng); //Checking that the longitude value is correct
            Assert.Equal("test", geo.location_type); //Checking that the location type is correct
        }

    }
}
