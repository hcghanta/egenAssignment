using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using OrderManagementAPI.Controllers;
using OrderManagementAPI.Models;
using OrderManagementAPI.Services;
using System;
using Xunit;

namespace OrderManagementTests
{
    public class ControllerTests
    {
        private static Mock<IServiceProvider> _serviceProvider;
        private static Mock<ILogger<OrderController>> _logger;
        private static Mock<IOrderService> _orderService;
        private static OrderController _orderController;

        public ControllerTests()
        {
            _logger = new Mock<ILogger<OrderController>>();
            _orderService = new Mock<IOrderService>();
            _serviceProvider = new Mock<IServiceProvider>();
            _orderController = new OrderController(_logger.Object, _orderService.Object);
        }
        [Fact]
        public async void OrderIdLessThan1_GetAPIShouldThrow500()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await _orderController.Get(0));
        }

        [Fact]
        public async void GivenValidOrderObject_CreateAPIShouldReturn200()
        {
            Order order = new Order()
            {
                Order_DeliveryType_Id = 2,
                Order_Subtotal = 10
            };
            _orderService.Setup(service => service.CreateOrder(order)).ReturnsAsync(true);
            var response = await _orderController.Post(order);
            var result = response as OkObjectResult;

            Assert.Equal(200, result.StatusCode);
        }
    }
}
