using OrderManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagementAPI.Repositories
{
    /// <summary>
    /// OrderRepository Interface
    /// </summary>
    public interface IOrderRepository
    {
        /// <summary>
        /// Get Order By Id
        /// </summary>
        Task<Order> GetOrderById(int orderId);

        /// <summary>
        /// Create New Orders
        /// </summary>
        Task<bool> CreateOrders(List<Order> orders);

        /// <summary>
        /// Update Orders
        /// </summary>
        Task<bool> UpdateOrders(List<Order> orders);

        /// <summary>
        /// Create New Order
        /// </summary>
        Task<bool> CreateOrder(Order order);

        /// <summary>
        /// Cancel Order
        /// </summary>
        Task<Order> CancelOrder(int orderId);
    }
}
