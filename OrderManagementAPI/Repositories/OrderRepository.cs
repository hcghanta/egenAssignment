using Microsoft.Extensions.Logging;
using OrderManagementAPI.Constants;
using OrderManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagementAPI.Repositories
{
    /// <summary>
    /// OrderRepository
    /// </summary>
    public class OrderRepository : IOrderRepository
    {
        private readonly ILogger<OrderRepository> _logger;

        private readonly OrderContext _context;

        /// <summary>
        /// OrderRepository Constructor
        /// </summary>
        public OrderRepository(ILogger<OrderRepository> logger, OrderContext context)
        {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// Get Order By Id
        /// </summary>
        public async Task<Order> GetOrderById(int orderId)
        {
            if (orderId < 1)
            {
                throw new ArgumentNullException($"{nameof(GetOrderById)}: OrderId cannot be empty or less than 1");
            }
            Order order = null;
            try
            {
                order = _context.OrderItems.SingleOrDefault(o => o.Order_Id == orderId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            return order;
        }

        /// <summary>
        /// Create New Orders
        /// </summary>
        public async Task<bool> CreateOrders(List<Order> orders)
        {
            if (orders == null || orders.Count < 1)
            {
                throw new ArgumentNullException($"{nameof(CreateOrders)}: Orders request object cannot be null");
            }
            bool result;
            try
            {
                foreach (var order in orders)
                {
                    order.Order_Status = OrderStatusConstants.New;
                }
                await _context.OrderItems.AddRangeAsync(orders);
                await _context.SaveChangesAsync();
                result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        /// <summary>
        /// Update Orders
        /// </summary>
        public async Task<bool> UpdateOrders(List<Order> orders)
        {
            if (orders.Any(o => o.Order_Id <= 0))
            {
                throw new ArgumentNullException($"{nameof(UpdateOrders)} Order_id cannot be empty or less than 1");
            }
            bool result;
            try
            {
                foreach (var order in orders)
                {
                    Order dbOrder = _context.OrderItems.FirstOrDefault(o => o.Order_Id == order.Order_Id);
                    dbOrder.Customer_Id = order.Customer_Id;
                    dbOrder.Modified_Date = DateTime.UtcNow;
                    dbOrder.Order_DeliveryType_Id = order.Order_DeliveryType_Id;
                    dbOrder.Order_Shipping_Address = order.Order_Shipping_Address;
                    dbOrder.Order_Shipping_Charges = order.Order_Shipping_Charges;
                    dbOrder.Order_Status = order.Order_Status;
                    dbOrder.Order_Subtotal = order.Order_Subtotal;
                    dbOrder.Order_Tax = order.Order_Tax;
                    dbOrder.Order_Total = order.Order_Total;
                    
                    await _context.SaveChangesAsync();
                }
          
                result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        /// <summary>
        /// Create New Order
        /// </summary>
        public async Task<bool> CreateOrder(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException($"{nameof(CreateOrder)}: Order request object cannot be null");
            }
            bool result;
            try
            {
                order.Order_Status = OrderStatusConstants.New;
                await _context.OrderItems.AddAsync(order);
                await _context.SaveChangesAsync();
                result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        /// <summary>
        /// Cancel Order
        /// </summary>
        public async Task<Order> CancelOrder(int orderId)
        {
            if (orderId < 1)
            {
                throw new ArgumentNullException($"{nameof(CancelOrder)}: Order_id cannot be empty or less than 1");
            }
            Order updatedOrder = null;
            try
            {
                updatedOrder = _context.OrderItems.SingleOrDefault(o => o.Order_Id == orderId);
                if (updatedOrder != null)
                {
                    updatedOrder.Order_Status = OrderStatusConstants.Cancel;
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return updatedOrder;
        }
    }
    
}
