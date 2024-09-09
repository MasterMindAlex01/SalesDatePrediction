using Microsoft.AspNetCore.Mvc;
using Moq;
using SalesDatePrediction.Application.Interfaces.Services;
using SalesDatePrediction.Application.Models.Responses;
using SalesDatePrediction.Shared.Wrapper;
using SalesDatePrediction.WebApi.Controllers;

namespace SalesDatePrediction.Test.Controllers
{
    public class EmployeesControllerTests
    {
        [Fact]
        public async Task Get_Returns_OkResult_With_Valid_Data()
        {
            // Arrange
            var mockService = new Mock<IEmployeeService>();
            mockService.Setup(service => service.GetAllEmployeeListAsync())
                .ReturnsAsync(await Result<List<EmployeeResponse>>.SuccessAsync(new List<EmployeeResponse>()
                {
                    new EmployeeResponse()
                    {
                        Empid = 1,
                        FullName = "Test",
                    }
                }));

            var controller = new EmployeesController(mockService.Object);

            // Act
            var result = await controller.GetAllEmployeeList();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<Result<List<EmployeeResponse>>>(okResult.Value);
            Assert.Single(returnValue.Data!);
        }
    }
}
