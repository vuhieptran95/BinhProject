using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BinhProjectMain.ViewModels.OrderHistory
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
    }

    public class OrderDetailsViewModel
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }
        public ProductViewModel Product { get; set; }
    }

    public class CustomerViewModel
    {
        public string CustomerId { get; set; }
        public string ContactName { get; set; }
    }

    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public IList<OrderDetailsViewModel> OrderDetails { get; set; }
    }

    public class OrderHistoryViewModel
    {
        public CustomerViewModel Customer { get; set; }
        public IList<OrderViewModel> Orders { get; set; }
    }
}