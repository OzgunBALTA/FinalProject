using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _productService.GetAll();
            if (result.Success == true)
            {
                //return Ok(result.Data); //Success = true ise sadece datayı döndürür.
                return Ok(result); //Tüm result parametrelerini döndürür. 200
            }

            return BadRequest(result); //Success = false ise sadece datayı döndürür. data=null success=false message="". 400
        }

        [HttpGet("getbyproductid")]
        public IActionResult GetByProductId(int productid)
        {
            var result = _productService.GetByProductId(productid);
            if (result.Success) //Default == true olarak çalışır.
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("transaction")]
        public IActionResult TransactionalOperation(Product product)
        {
            var result = _productService.TransactionalOperation(product);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
