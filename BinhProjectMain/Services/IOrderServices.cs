using BinhProjectMain.Models;
using BinhProjectMain.ViewModels.OrderHistory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BinhProjectMain.Services
{
    public interface IOrderServices
    {
        OrderHistoryViewModel GetOrdersByCustomerId(string customerId);
    }

    public class OrderServices : IOrderServices
    {
        private readonly NorthwindContext _context;

        public OrderServices(NorthwindContext context)
        {
            _context = context;
        }
        public OrderHistoryViewModel GetOrdersByCustomerId(string customerId)
        {
            var customer = _context.Customers
                .Select(c => new CustomerViewModel {
                    CustomerId = c.CustomerId,
                    ContactName = c.ContactName
                })
                .SingleOrDefault(c => c.CustomerId == customerId);
            var orders = _context.Orders
                .Where(o => o.CustomerId == customerId);

            return new OrderHistoryViewModel
            {
                Customer = customer
            };
                
        }
    }
}
