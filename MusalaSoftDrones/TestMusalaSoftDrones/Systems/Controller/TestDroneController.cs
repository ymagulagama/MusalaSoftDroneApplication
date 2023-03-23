using FakeItEasy;

using FluentAssertions;

using Microsoft.AspNetCore.Mvc;

using Moq;

using MusalaSoftDrones.Api.Controllers;
using MusalaSoftDrones.Api.DomainEntities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMusalaSoftDrones.Systems.Controller
{
    public class TestDroneController
    {
        [Fact]
        public async void GetDron_OnSuccess_ReturnStatus200()
        {
            //Arrange
            var fakeService = A.Fake<IMusalaSoftRepository>();
            var droneController = new DronesController(fakeService);
            //Act
            var actionResult = await droneController.GetAllDrone();
            var result = actionResult.Result as OkObjectResult;
            //Assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async void GetDron_OnSuccess_InvokesDrone()
        {
            //Arrange
            var mockService = new Mock<IMusalaSoftRepository>();
            mockService.Setup(service => service.GetAllDrone()).ReturnsAsync(new List<Drone>());
            var droneController = new DronesController(mockService.Object);
            //Act
            var actionResult = await droneController.GetAllDrone();
            var result = actionResult.Result as OkObjectResult;
            //Assert
            mockService.Verify(service => service.GetAllDrone(), Moq.Times.Once());
        }
    }
}
