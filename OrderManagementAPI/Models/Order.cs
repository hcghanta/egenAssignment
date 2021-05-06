using System;
using System.ComponentModel.DataAnnotations;

namespace OrderManagementAPI.Models
{
    public class Order
    {
        [Key]
        public int Order_Id { get; set; }

        public string Order_Status { get; set; }
        
        public decimal Order_Subtotal { get; set; }

        public decimal Order_Total { get; set; }
        
        public decimal Order_Tax { get; set; }
        
        public decimal Order_Shipping_Charges { get; set; }
        
        public DateTime Created_Date { get; set; }
        
        public DateTime Modified_Date { get; set; }
        
        public int Customer_Id { get; set; }
        
        public int Order_Shipping_Address { get; set; }
        
        public int Order_DeliveryType_Id { get; set; }

    }
}