using Microsoft.AspNetCore.Mvc;
using Shopping.ProductAPI.Data.ValueObjects;
using Shopping.ProductAPI.Repository.Interface;

namespace Shopping.ProductAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new
                ArgumentNullException(nameof(productRepository));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductVO>> FindById(long id)
        {
            try
            {
                var product = await _productRepository.FindById(id);
                if (product == null) return NotFound("Produto não encontrado!");
                return Ok(product);
            }
            catch (Exception ex)
            {
               return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductVO>>> FindAll()
        {
            var products = await _productRepository.FindAll();
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult<ProductVO>> Create([FromBody] ProductVO productRequest)
        {
            try
            {
                if (productRequest == null) return BadRequest("Produto request não informado.");
                var product = await _productRepository.Create(productRequest);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<ProductVO>> Update([FromBody] ProductVO productRequest)
        {
            try
            {
                if (productRequest == null) return BadRequest("Produto request não informado.");
                var product = await _productRepository.Update(productRequest);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            try
            {
                var _product = await _productRepository.FindById(id);
                if (_product == null)
                    return BadRequest("Produto não encontrado!");
                var status = await _productRepository.Delete(_product.Id);
                if (!status)
                    return BadRequest("Ocorreu um erro ao deletar um produto");
                return Ok(status);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
