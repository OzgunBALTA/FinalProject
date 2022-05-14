using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

            //ProductTest(productManager);

            //CategoryTest(categoryManager);


        }

        private static void CategoryTest(CategoryManager categoryManager)
        {
            Console.WriteLine("------------------------------------------");
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
            Console.WriteLine("------------------------------------------");
            var c = categoryManager.GetById(1);
            Console.WriteLine(c.CategoryName);
        }

        private static void ProductTest(ProductManager productManager)
        {
            foreach (var product in productManager.GetAll())
            {
                Console.WriteLine(product.ProductName);
            }
            Console.WriteLine("------------------------------------------");
            foreach (var product in productManager.GetByCategory(1))
            {
                Console.WriteLine(product.ProductName);
            }
            Console.WriteLine("------------------------------------------");
            foreach (var product in productManager.GetByUnitPrice(50, 100))
            {
                Console.WriteLine(product.ProductName);
            }
            Console.WriteLine("------------------------------------------");
            foreach (var product in productManager.GetProductDetails())
            {
                Console.WriteLine($"{product.ProductName} / {product.CategoryName} / {product.UnitsInStock}");
            }
        }
    }
}
