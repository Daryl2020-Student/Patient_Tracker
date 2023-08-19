using NUnit.Framework;
using Patient_Tracker.Model;

namespace Patient_Tracker.Tests.Model_Tests
{
    public class GeometryTests
    {
        public void Geometry_PropertiesInitialized_Successfully()
        {
            // Arrange
            var location = new Location { lat = 50.00, lng = -50.00 };
            var geometry = new Geometry
            {
                location = location,
                location_type = "Point"
            };

            // Act - No specific action required as we're testing property initialization

            // Assert
            Assert.IsNotNull(geometry);
            Assert.AreSame(location, geometry.location);
            Assert.AreEqual("Point", geometry.location_type);
        }
    }
}