using Microsoft.AspNetCore.Mvc;
using Moq;
using SalesDatePrediction.Application.Interfaces.Services;
using SalesDatePrediction.Application.Models.Responses;
using SalesDatePrediction.Shared.Wrapper;
using SalesDatePrediction.WebApi.Controllers;

namespace SalesDatePrediction.Test.Controllers
{
    public class ShippersControllerTests
    {
        [Fact]
        public async Task Get_Returns_OkResult_With_Valid_Data()
        {
            // Arrange
            var mockService = new Mock<IShipperService>();
            mockService.Setup(service => service.GetAllShipperListAsync())
                .ReturnsAsync(await Result<List<ShipperResponse>>.SuccessAsync(new List<ShipperResponse>()
                {
                    new ShipperResponse()
                    {
                        ShipperId = 1,
                        CompanyName = "Test",
                    }
                }));

            var controller = new ShippersController(mockService.Object);

            // Act
            var result = await controller.GetAllShipperList();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<Result<List<ShipperResponse>>>(okResult.Value);
            Assert.Single(returnValue.Data!);
        }
    }
}
