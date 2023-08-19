using Patient_Tracker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patient_Tracker_Test.Models
{
    public class LocationTest
    {

        [Fact]
        public void LocLocationModelTest()
        {

            Location loc = new();

            // Arrange
            loc.lat = 53.3498;
            loc.lng = 6.2603;

            // Act
            var result = loc;

            // Assert
            Assert.Equal(53.3498, result.lat);
            Assert.Equal(6.2603, result.lng);
            

        }
    }
}
