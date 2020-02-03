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
        public string Predicate { get; set; }
        public IEnumerable<OrderDto> Orders { get; set; }

        public static Expression<Func<Customers, CustomerDto>> Projection = c => new CustomerDto
        {
            CompanyName = c.CompanyName,
            CustomerId = c.CustomerId,
            ContactName = c.ContactName,
            Orders = c.Orders.Select(OrderDto.Projection).ToList()
        };
    }

    public class DtoProjection
    {
        public DtoProjection(DateTime fromOrderDate, decimal number)
        {
            _fromOrderDate = fromOrderDate;
            _number = number;
        }
        public Expression<Func<Customers, CustomerDto>> CustomerProjection = c => new CustomerDto
        {
            CompanyName = c.CompanyName,
            CustomerId = c.CustomerId,
            ContactName = c.ContactName,
            Orders = c.Orders.Where(o => o.Freight > _number).Select(OrderDto.Projection).ToList()
        };

        public Expression<Func<Orders, OrderDto>> OrderProjection = o => new OrderDto
        {
            CustomerId = o.CustomerId,
            EmployeeId = o.EmployeeId,
            OrderDate = o.OrderDate,
            OrderId = o.OrderId,
            Employee = new EmployeeDto
            {
                EmployeeId = o.Employee.EmployeeId,
                FirstName = o.Employee.FirstName,
                LastName = o.Employee.LastName
            }
        };
        public DateTime _fromOrderDate;
        private readonly decimal _number;
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
            Employee = new EmployeeDto
            {
                EmployeeId = o.Employee.EmployeeId,
                FirstName = o.Employee.FirstName,
                LastName = o.Employee.LastName
            }
        };
    }

    public class EmployeeDto
    {
        public int EmployeeId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }
}
