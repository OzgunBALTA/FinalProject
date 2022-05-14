using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    //Düzenleyeceğim.
    public class InMemoryProductDal : IProductDal //Düzeltilecek
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            //Oracle, Sql Server, Postgres, MongoDb gibi DBlerden geliyomuş gibi simülasyon oluşturdum.
            _products = new List<Product>
            {
                new Product { ProductId = 1, CategoryId = 1, ProductName = "Bardak", UnitPrice = 10, UnitsInStock = 20 },
                new Product { ProductId = 2, CategoryId = 1, ProductName = "Fincan", UnitPrice = 15, UnitsInStock = 30 },
                new Product { ProductId = 3, CategoryId = 2, ProductName = "Telefon", UnitPrice = 3000, UnitsInStock = 10 },
                new Product { ProductId = 4, CategoryId = 2, ProductName = "Bilgisayar", UnitPrice = 3500, UnitsInStock = 15 },
                new Product { ProductId = 5, CategoryId = 3, ProductName = "Çamaşır Makinası", UnitPrice = 4500, UnitsInStock = 15 }
            };
        }
        public void Add(Product product)
        {
            _products.Add(product); //DB liste olduğu için listeye ekleme komutu.
        }

        public void Delete(Product product)
        {
            Product productToDelete = _products.SingleOrDefault(x => x.ProductId == product.ProductId);
            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products.OrderBy(x=> x.ProductId).ToList();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId) //Kategoriye göre filtreleme
        {
            return _products.Where(x => x.CategoryId == categoryId).ToList();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(x => x.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}
