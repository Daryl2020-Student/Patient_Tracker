using Patient_Tracker.Model; // Assuming this is the correct namespace for your ZipModel class

namespace Patient_Tracker_Test.Model
{
    public class ZipModelTests
    {
        [Fact]
        public void ZipModel_Properties_SetAndGetCorrectly()
        {
            // Arrange
            var addressComponents = new List<AddressComponent>
            {
                new AddressComponent { long_name= "Beans", short_name ="Bean"}
            };

            var geometry = new Geometry
            {
                // Act
                location = new Location
                {
                    lat = 50.0,
                    lng = -50.0
                },
            };

            // Act
            var zipModel = new ZipModel
            {
                address_components = addressComponents,
                formatted_address = "Formatted_Beans_Address",
                geometry = geometry,
                place_id = "Beans_Place"
            };

            // Assert
            Assert.Equal(addressComponents, zipModel.address_components);
            Assert.Equal("Formatted_Beans_Address", zipModel.formatted_address);
            Assert.Equal(geometry, zipModel.geometry);
            Assert.Equal("Beans_Place", zipModel.place_id);
            Assert.Equal(50.0, zipModel.geometry.location.lat);
            Assert.Equal(-50.0, zipModel.geometry.location.lng);
        }
    }
}
