using NUnit.Framework;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Patient_Tracker.Pages.Bookings;

using Patient_Tracker.Data;
using Patient_Tracker.Model;

namespace Patient_Tracker.Tests.Pages.Bookings
{
    [TestFixture]
    public class Geomtry_Tests

    {
        private Mock<Patient_Tracker_Context> _contextMock;

        [SetUp]
        public void Setup()
        {
            _contextMock = new Mock<Patient_Tracker_Context>();
        }

        [Test]
        public async Task OnPostAsync_ValidModel_Success()
        {
            // Arrange
            var model = new CreateModel(_contextMock.Object)
            {
                Booking = new Booking
                {
                    // Initialize Booking properties
                }
            };

            // Act
            var result = await model.OnPostAsync();

            // Assert
            Assert.IsInstanceOf<RedirectToPageResult>(result);
         
        }

    }
}
