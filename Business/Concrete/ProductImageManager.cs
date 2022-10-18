using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductImageManager : IProductImageService
    {

        IProductImageDal _productImageDal;
        IFileHelper _fileHelper;

        public ProductImageManager(IProductImageDal productImageDal, IFileHelper fileHelper)
        {
            _productImageDal = productImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile file, ProductImage productImage)
        {
            productImage.ImagePath = _fileHelper.Upload(file, PathConstants.ImagesPath);
            productImage.ImageDate = DateTime.Now;
            _productImageDal.Add(productImage);
            return new SuccessResult(Messages.ProductImageUploaded);
        }

        public IResult Delete(ProductImage productImage)
        {
            _fileHelper.Delete(PathConstants.ImagesPath + productImage);
            _productImageDal.Delete(productImage);
            return new SuccessResult(Messages.ProductImageDeleted);
        }

        public IDataResult<List<ProductImage>> GetAll()
        {
            return new SuccessDataResult<List<ProductImage>>(_productImageDal.GetAll());
        }

        public IDataResult<List<ProductImage>> GetProductImageByProductId(int productId)
        {
            //var result = BusinessRules.Run(CheckIfProductImageNull(productId));
            //if (!result.Success)
            //{
            //    return new ErrorDataResult<List<ProductImage>>(GetDefaultImage(productId).Data);
            //}

            return new SuccessDataResult<List<ProductImage>>(_productImageDal.GetAll(p => p.ProductId == productId));
        }

        public IResult Update(IFormFile file, ProductImage productImage)
        {
            _fileHelper.Update(file, productImage.ImagePath + PathConstants.ImagesPath, PathConstants.ImagesPath);
            _productImageDal.Update(productImage);
            return new SuccessResult(Messages.ProductImageUpdated);
        }

        private IDataResult<List<ProductImage>> GetDefaultImage(int productId)
        {
            List<ProductImage> productImages = new List<ProductImage>();
            productImages.Add(new ProductImage { Id = productId, ImageDate = DateTime.Now, ImagePath = "DefaultImage.jpg" });
            return new SuccessDataResult<List<ProductImage>>(productImages);
        }

        private IResult CheckIfProductImageNull(int productId)
        {
            var result = _productImageDal.GetAll(p => p.ProductId == productId).Count;
            if (result > 0)
            {
                return new SuccessResult();
            }

            return new ErrorResult();
        }

        public IDataResult<ProductImage> GetById(int id)
        {
            return new SuccessDataResult<ProductImage>(_productImageDal.Get(p => p.Id == id));
        }
    }
}
