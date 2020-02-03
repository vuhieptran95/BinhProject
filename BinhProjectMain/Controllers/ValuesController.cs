using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BinhProjectMain.Models;
using BinhProjectMain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BinhProjectMain.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly NorthwindContext _context;
        private readonly ILogger<ValuesController> _logger;
        private readonly IOrderServices _orderServices;
        private readonly IProductServices _productServices;
        private readonly ICategoryServices _categoryServices;

        public ValuesController(NorthwindContext context, ILogger<ValuesController> logger,
            IOrderServices orderServices,
            IProductServices productServices,
            ICategoryServices categoryServices)
        {
            _context = context;
            _logger = logger;
            _orderServices = orderServices;
            _productServices = productServices;
            _categoryServices = categoryServices;
        }
        // GET api/values
        [HttpGet]
        public ActionResult Get()
        {
            var result = 1;

            using (var transaction = _context.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
            {
                try
                {
                    // var cat = _categoryServices.AddCategory(new Categories()
                    // {
                    //     CategoryName = "Test"
                    // });

                    var cat2 = _context.Categories.Add(new Categories()
                    {
                        CategoryName = "Test"
                    });
                    _context.SaveChanges();
                    

                    _productServices.AddProduct(new Products()
                    {
                        // CategoryId = cat.CategoryId,
                        CategoryId = cat2.Entity.CategoryId,
                        ProductName = "Test Product",
                        Discontinued = false
                    });
                    
                    // throw new Exception("Fuck this");
                
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
                
                
            }
            
            return Ok(result);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var product = _context.Products.SingleOrDefault(p => p.ProductId == id);
            _logger.LogDebug("Log thoi", product);
            return Ok(product);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
