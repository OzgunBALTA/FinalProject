﻿using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetByCategoryId(int productId);
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);
        IDataResult<List<ProductDetailDto>> GetProductsDetails();
        IDataResult<List<ProductDetailDto>> GetProductDetailsById(int productId);
        IDataResult<Product> GetByProductId(int productId);
        IResult Add(Product product);
        IResult Delete(Product product);
        IResult Update(Product product);
        IResult TransactionalOperation(Product product);

    }
}
