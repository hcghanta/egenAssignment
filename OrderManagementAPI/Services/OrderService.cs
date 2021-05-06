using Microsoft.Extensions.Configuration;
using OrderManagementAPI.Models;
using OrderManagementAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagementAPI.Services
{
    /// <summary>
    /// OrderService
    /// </summary>
    public class OrderService : IOrderService
    {
        private IOrderRepository _orderRepository;

        /// <summary>
        /// OrderService Constructor
        /// </summary>
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
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
            Order order = await _orderRepository.GetOrderById(orderId);
            return order;
        }

        /// <summary>
        /// Create Orders
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
                await _orderRepository.CreateOrders(orders);
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
                throw new ArgumentNullException($"{nameof(UpdateOrders)}: Order_id cannot be empty or less than 1");
            }
            bool result;
            try
            {
                await _orderRepository.UpdateOrders(orders);
                result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// Create Orders
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
                bool response = await _orderRepository.CreateOrder(order);
                result = response;
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
            Order order = null;
            try
            {
                order = await _orderRepository.CancelOrder(orderId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return order;
        }

    }
}
