using OrderManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagementAPI.Services
{
    /// <summary>
    /// OrderService Interface
    /// </summary>
    public interface IOrderService
    {
        /// <summary>
        /// Get Order By Id
        /// </summary>
        Task<Order> GetOrderById(int orderId);

        /// <summary>
        /// Create Order
        /// </summary>
        Task<bool> CreateOrder(Order order);

        /// <summary>
        /// Create Orders
        /// </summary>
        Task<bool> CreateOrders(List<Order> orders);

        /// <summary>
        /// Update Orders
        /// </summary>
        Task<bool> UpdateOrders(List<Order> orders);

        /// <summary>
        /// Cancel Order
        /// </summary>
        Task<Order> CancelOrder(int orderId);

    }
}
