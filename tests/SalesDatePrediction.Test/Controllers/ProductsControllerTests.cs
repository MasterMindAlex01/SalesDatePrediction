using Microsoft.AspNetCore.Mvc;
using Moq;
using SalesDatePrediction.Application.Interfaces.Services;
using SalesDatePrediction.Application.Models.Responses;
using SalesDatePrediction.Shared.Wrapper;
using SalesDatePrediction.WebApi.Controllers;

namespace SalesDatePrediction.Test.Controllers
{
    public class ProductsControllerTests
    {
        [Fact]
        public async Task Get_Returns_OkResult_With_Valid_Data()
        {
            // Arrange
            var mockService = new Mock<IProductService>();
            mockService.Setup(service => service.GetAllProductListAsync())
                .ReturnsAsync(await Result<List<ProductResponse>>.SuccessAsync(new List<ProductResponse>()
                {
                    new ProductResponse()
                    {
                        ProductId = 1,
                        ProductName = "Test",
                    }
                }));

            var controller = new ProductsController(mockService.Object);

            // Act
            var result = await controller.GetAllProductList();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<Result<List<ProductResponse>>>(okResult.Value);
            Assert.Single(returnValue.Data!);
        }
    }
}
