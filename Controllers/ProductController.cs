using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductCRUD.Exceptions;
using ProductCRUD.Managers;
using ProductCRUD.Models;

namespace ProductCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductManager _manager;

        public ProductController(IProductManager manager)
        {
            _manager = manager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductModel model)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _manager.AddProductAsync(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] ProductFilter filter)
        {
            var products = await _manager.GetProductsAsync(filter);
            return Ok(products);
        }

        [HttpGet("productId")]
        public async Task<IActionResult> GetProductById(Guid productId)
        {
            try
            {
                return Ok(await _manager.GetProductByIdAsync(productId));
            }
            catch(ProductNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(Guid productId, CreateProductModel model)
        {
            try
            {
                return Ok(await _manager.UpdateProductAsync(productId, model));
            }
            catch (ProductNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DelateProduct(Guid productId)
        {
            try
            {
                await _manager.DeleteProductAsync(productId);
                return Ok();
            }
            catch (ProductNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
