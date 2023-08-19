using Patient_Tracker.Model;

namespace Patient_Tracker_Test.Models
{
    public class Geometrytest
    {
        [Fact]
        public void GeometryModel()
        {
            // Arrange
            Geometry geo = new()
            {
                // Act
                location = new Location
                {
                    lat = 50.0,
                    lng = -50.0
                },
                location_type = "test"
            };

            // Assert
            Assert.NotNull(geo);
            Assert.NotNull(geo.location);
            Assert.Equal(50.0, geo.location.lat);
            Assert.Equal(-50.0, geo.location.lng);
            Assert.Equal("test", geo.location_type);
        }

    }
}
