using CoverletAsyncRepro.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace CoverletAsyncRepro.Tests
{
    public class ReproControllerTest
    {
        [Fact]
        public void PostTest_NullFile_ShouldReturnBadRequest()
        {
            // Arrange
            var target = new ReproController();

            // Act
            var result = target.Post(null);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Result);
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }
    }
}
