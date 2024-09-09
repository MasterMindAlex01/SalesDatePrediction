using Microsoft.AspNetCore.Mvc;
using Moq;
using SalesDatePrediction.Application.Interfaces.Services;
using SalesDatePrediction.Application.Models.Requests;
using SalesDatePrediction.Application.Models.Responses;
using SalesDatePrediction.Domain.Entities;
using SalesDatePrediction.Shared.Wrapper;
using SalesDatePrediction.WebApi.Controllers;

namespace SalesDatePrediction.Test.Controllers
{
    public class CustomersControllerTests
    {
        [Fact]
        public async Task Get_Returns_OkResult_With_Valid_Data()
        {
            // Arrange
            var queryfilter = new CustomerQueryFilterRequest();
            var mockService = new Mock<ICustomerService>();
            mockService.Setup(service => service.GetSaleDatePredictionPagedListAsync(queryfilter))
                .ReturnsAsync(new PaginatedResult<CustomerResponse>(new List<CustomerResponse>())
                {
                    TotalCount = 1,
                });

            var controller = new CustomersController(mockService.Object);

            // Act
            var result = await controller.GetSaleDatePredictionPagedList(queryfilter);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<PaginatedResult<CustomerResponse>>(okResult.Value);
            Assert.Equal(1, returnValue.TotalCount);
        }
    }
}
