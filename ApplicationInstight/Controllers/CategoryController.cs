using ApplicationInstight.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ApplicationInstight.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public CategoryController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var result = _appDbContext.Categories.ToList();
            return Ok(result);
        }
        [HttpPost]
        public IActionResult Post(Category loai)
        {
            Category result = loai;
            _appDbContext.Add(loai);
            _appDbContext.SaveChanges();
            return Ok(result);

        }

    }
}
