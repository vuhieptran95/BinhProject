using BinhProjectMain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BinhProjectMain.Dto
{
    public class CustomerDto
    {
        public CustomerDto()
        {
            Orders = new List<OrderDto>();
        }

        public string CustomerId { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public IEnumerable<OrderDto> Orders { get; set; }
        public static Expression<Func<Customers, CustomerDto>> Projection = c => new CustomerDto
        {
            CompanyName = c.CompanyName,
            CustomerId = c.CustomerId,
            ContactName = c.ContactName,
            Orders = c.Orders.Select(o => OrderDto.Projection.Compile().Invoke(o)).ToList()
        };
    }

    public class OrderDto
    {
        public int OrderId { get; set; }
        public string CustomerId { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? OrderDate { get; set; }
        public EmployeeDto Employee { get; set; }
        public static Expression<Func<Orders, OrderDto>> Projection = o => new OrderDto
        {
            CustomerId = o.CustomerId,
            EmployeeId = o.EmployeeId,
            OrderDate = o.OrderDate,
            OrderId = o.OrderId,
            //Employee = EmployeeDto.Projection.Compile().Invoke(o.Employee)
        };
    }

    public class EmployeeDto
    {
        public int EmployeeId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public static Expression<Func<Employees, EmployeeDto>> Projection = e => new EmployeeDto
        {
            EmployeeId = e.EmployeeId,
            FirstName = e.FirstName,
            LastName = e.LastName
        };
    }
}
