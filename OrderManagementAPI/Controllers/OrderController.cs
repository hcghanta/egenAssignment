using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrderManagementAPI.Models;
using OrderManagementAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagementAPI.Controllers
{
    /// <summary>
    /// Order Controller
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private IOrderService _orderService;

        /// <summary>
        /// Constructor for Order Controller
        /// </summary>
        public OrderController(ILogger<OrderController> logger, IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
        }

        /// <summary>
        /// API to get Order Details
        /// </summary>
        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] int orderId)
        {
            if (orderId < 1)
            {
                throw new ArgumentNullException($"{nameof(Get)}: OrderId cannot be empty or less than 1");
            }
            var response = await _orderService.GetOrderById(orderId);
            return Ok(response);
        }

        /// <summary>
        /// API to get Create New order
        /// </summary>
        [HttpPost("order")]
        public async Task<ActionResult> Post([FromBody] Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException($"{nameof(Post)}: Order request object cannot be null");
            }
            var response = await _orderService.CreateOrder(order);
            return Ok(response);
        }

        /// <summary>
        /// API for Bulk Order Creation
        /// </summary>
        [HttpPost("orders")]
        public async Task<ActionResult> PostOrders([FromBody] List<Order> orders)
        {
            if (orders == null || orders.Count < 1)
            {
                throw new ArgumentNullException($"{nameof(PostOrders)}: Orders request object cannot be null");
            }
            var response = await _orderService.CreateOrders(orders);
            return Ok(response);
        }

        /// <summary>
        /// API for Bulk Order Updates
        /// </summary>
        [HttpPut("orders")]
        public async Task<ActionResult> PostUpdateOrders([FromBody] List<Order> orders)
        {
            if (orders.Any(o => o.Order_Id <= 0))
            {
                throw new ArgumentNullException($"{nameof(PostUpdateOrders)}: Order_id cannot be empty or less than 1");
            }
            var response = await _orderService.UpdateOrders(orders);
            return Ok(response);
        }

        /// <summary>
        /// API to Cancel Order
        /// </summary>
        [HttpPut]
        public async Task<ActionResult> Put([FromQuery] int orderId)
        {
            if (orderId < 1)
            {
                throw new ArgumentNullException($"{nameof(Put)}: Order_id cannot be empty or less than 1");
            }
            var response = await _orderService.CancelOrder(orderId);
            return Ok(response);
        }
    }
}
