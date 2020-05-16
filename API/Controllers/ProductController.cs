using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {
    [ApiController]
    [Route ("api/[controller]")]
    public class ProductController : ControllerBase {
        private readonly IGenericRepository<Product> productRepo;
        private readonly IGenericRepository<ProductBrand> productBrandRepo;
        private readonly IGenericRepository<ProductType> productTypeRepos;

        public ProductController (IGenericRepository<Product> productRepo,
            IGenericRepository<ProductBrand> productBrandRepo,
            IGenericRepository<ProductType> productTypeRepos
        ) {
            this.productRepo = productRepo;
            this.productBrandRepo = productBrandRepo;
            this.productTypeRepos = productTypeRepos;
        }

        [HttpGet ("{id}")]
        public async Task<ActionResult> GetProductByIdAsync (int id) {
            var products = await productRepo.GetByIdAsync (id);
            return Ok (products);
        }

        [HttpGet]
        public async Task<ActionResult> GetProductsAsync () {
            var products = await productRepo.ListAllAsync ();
            return Ok (products);
        }

        [HttpGet ("brands")]
        public async Task<ActionResult> GetProductBrandsAsync () {
            var productBrands = await productBrandRepo.ListAllAsync ();
            return Ok (productBrands);
        }

        [HttpGet ("brands")]
        public async Task<ActionResult> GetProductTypesAsync () {
            var productTypes = await productTypeRepos.ListAllAsync ();
            return Ok (productTypes);
        }

    }
}