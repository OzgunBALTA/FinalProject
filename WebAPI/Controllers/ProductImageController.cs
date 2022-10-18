using Business.Abstract;
using Core.Utilities.Helpers.FileHelper.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        IProductImageService _productImageService;

        public ProductImageController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm(Name = ("ImagePath"))] IFormFile file, [FromForm] ProductImage productImage)
        {
            var result = _productImageService.Add(file, productImage);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete([FromForm(Name = ("Id"))] int id)
        {
            var productImage = _productImageService.GetById(id).Data;
            var result = _productImageService.Delete(productImage);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm (Name = "ImagePath")] IFormFile file, [FromForm (Name = "Id")] int id)
        {
            var productImage = _productImageService.GetById(id).Data;
            var result = _productImageService.Update(file, productImage);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _productImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getimagesbyproductid")]
        public IActionResult GetProductImageByProductId(int id)
        {
            var result = _productImageService.GetProductImageByProductId(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
