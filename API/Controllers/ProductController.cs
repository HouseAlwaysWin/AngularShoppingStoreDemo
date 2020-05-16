using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {
    [ApiController]
    [Route ("api/[controller]")]
    public class ProductController : ControllerBase {
        public ProductController()
        {
        }

        [HttpGet]
        public string GetProducts () {
            return "products";
        }
    }
}