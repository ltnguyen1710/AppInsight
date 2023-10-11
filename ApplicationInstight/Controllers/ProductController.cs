using App.Metrics;
using ApplicationInstight.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace ApplicationInstight.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly AppDbContext _appDbContext;
        private readonly IMetrics _metrics;

        public ProductController(ILogger<ProductController> logger, AppDbContext appDbContext, IMetrics metrics)
        {
            _logger = logger;
            _appDbContext = appDbContext;
            _metrics = metrics;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _appDbContext.Products.ToList();
            return Ok(result);
        }
        [HttpPost]
        public IActionResult Post(Product product)
        {
            Product result = product;
            _appDbContext.Add(result);
            _appDbContext.SaveChanges();
            _metrics.Measure.Counter.Increment(MetricsRegistry.CreatedCustomerCounter);
            return Ok(result);
        }
    }
}
