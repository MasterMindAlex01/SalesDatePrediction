using Microsoft.AspNetCore.Mvc;
using Moq;
using SalesDatePrediction.Application.Interfaces.Services;
using SalesDatePrediction.Application.Models.Requests;
using SalesDatePrediction.Application.Models.Responses;
using SalesDatePrediction.Shared.Wrapper;
using SalesDatePrediction.WebApi.Controllers;

namespace SalesDatePrediction.Test.Controllers
{
    public class OrdersControllerTests
    {
        [Fact]
        public async Task Get_Returns_OkResult_With_Valid_Data()
        {
            // Arrange
            var queryfilter = new OrderQueryFilterRequest();
            var mockService = new Mock<IOrderService>();
            mockService.Setup(service => service.GetOrderPagedListByCustIdAsync(queryfilter))
                .ReturnsAsync(new PaginatedResult<OrderResponse>(new List<OrderResponse>())
                {
                    TotalCount = 1,
                });

            var controller = new OrdersController(mockService.Object);

            // Act
            var result = await controller.GetOrderListByCustId(queryfilter);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<PaginatedResult<OrderResponse>>(okResult.Value);
            Assert.Equal(1, returnValue.TotalCount);
        }
    }
}
