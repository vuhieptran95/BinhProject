using BinhProjectMain.Models;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Linq;

namespace BinhProjectMain.Migrations
{
    public partial class TestUsingContext : Migration
    {
        private readonly NorthwindContext _context;

        
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            using (var _context = new NorthwindContext())
            {
                var customer = _context.Customers.First(c => c.CustomerId == "ALFKI");
                customer.City = "Berlin 2";

                _context.SaveChanges();
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
