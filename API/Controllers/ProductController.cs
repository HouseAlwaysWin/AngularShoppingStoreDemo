using System.Threading.Tasks;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {
    [ApiController]
    [Route ("api/[controller]")]
    public class ProductController : ControllerBase {
        private IProductRepository _repo;
        public ProductController (IProductRepository repo) {
            _repo = repo;
        }

        [HttpGet ("{id}")]
        public async Task<ActionResult> GetProductByIdAsync (int id) {
            var products = await _repo.GetProductByIdAsync (id);
            return Ok (products);
        }

        [HttpGet]
        public async Task<ActionResult> GetProductsAsync () {
            var products = await _repo.GetProductsAsync ();
            return Ok (products);
        }

        [HttpGet ("brands")]
        public async Task<ActionResult> GetProductBrandsAsync () {
            var productBrands = await _repo.GetProductBrandsAsync ();
            return Ok (productBrands);
        }

        [HttpGet ("brands")]
        public async Task<ActionResult> GetProductTypesAsync () {
            var productTypes = await _repo.GetProductTypesAsync ();
            return Ok (productTypes);
        }

    }
}