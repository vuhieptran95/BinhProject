using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BinhProjectMain.Models;
using BinhProjectMain.Services;
using Microsoft.AspNetCore.Mvc;
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

        public ValuesController(NorthwindContext context, ILogger<ValuesController> logger, IOrderServices orderServices)
        {
            _context = context;
            _logger = logger;
            _orderServices = orderServices;
        }
        // GET api/values
        [HttpGet]
        public ActionResult Get()
        {
            var result = _orderServices.GetOrdersByCustomerId("ANATR");
            //var products = _context.Products.ToList();
            //_logger.LogDebug("Log thoi {@products}", products);
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
