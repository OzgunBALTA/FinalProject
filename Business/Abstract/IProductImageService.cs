using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductImageService
    {
        IResult Add(IFormFile file, ProductImage productImage);
        IResult Delete(ProductImage productImage);
        IResult Update(IFormFile file, ProductImage productImage);
        IDataResult<List<ProductImage>> GetProductImageByProductId(int id);
        IDataResult<List<ProductImage>> GetAll();
        IDataResult<ProductImage> GetById(int id);
    }
}
