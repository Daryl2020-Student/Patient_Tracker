using Microsoft.AspNetCore.Mvc.RazorPages;
using Moq;
using Patient_Tracker.Pages;
using Patient_Tracker.Data;
using Patient_Tracker.Model;

namespace Patient_Tracker_Test.Pages
{
    public class IndexModelTests
    {
        [Fact]
        public void OnPost_WithInvalidInput_ReturnsPage() // Test method for invalid doctor credentials
        {
            // Arrange
            var mockContext = new Mock<Patient_Tracker_Context>(); // Mock the database context

            var pageModel = new IndexModel(mockContext.Object); // Create a new IndexModel object
            pageModel.Doctor = new Doctor
            {
                Email = string.Empty, // Empty email
                Password = string.Empty // Empty password
            };

            var pageModel2 = new IndexModel(mockContext.Object); // Create a new IndexModel object
            pageModel2.Doctor = new Doctor()

            {
                Email = "", // Invalid email
                Password = "" // Invalid password
            };

            // Act
            var result = pageModel.OnPost(); // Call the OnPost method
            var result2 = pageModel2.OnPost(); // Call the OnPost method

            // Assert
            Assert.IsType<PageResult>(result); // Check that the result is a PageResult
            Assert.False(pageModel.ShowNavbar); // Check that the navbar is not shown
            Assert.IsType<PageResult>(result2); // Check that the result is a PageResult
            Assert.False(pageModel2.ShowNavbar); // Check that the navbar is not shown
        }        
    }
}
