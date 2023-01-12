using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController] // Attribute , Java -> Annotation
    public class ProductsController : ControllerBase
    {
        //Loosely coupled
        //Naming convention
        //IoC container --> Inversion of Control
        IProductService _productService; // Default private

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            //Dependency chain
            //IProductService productService = new ProductManager(new EfProductDal());
            //var result = productService.GetAll();
            //return result.Data;

            var result = _productService.GetAll();
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getById")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult DeleteById(Product product) 
        {
            var result = _productService.Delete(product);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
