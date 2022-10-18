using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
        //    ProductManager productManager = new ProductManager(new EfProductDal(), new CategoryManager(new EfCategoryDal()));
        //    CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

        //    //ProductTest(productManager);

        //    //CategoryTest(categoryManager);

        //    IDataResultTest(productManager);

        //}

        //private static void IDataResultTest(ProductManager productManager)
        //{
        //    var result = productManager.GetProductDetails();

        //    if (result.Success == true)
        //    {
        //        foreach (var product in result.Data)
        //        {
        //            Console.WriteLine(product.ProductName + "/" + product.CategoryName);
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine(result.Message);
        //    }
        //}

        //private static void CategoryTest(CategoryManager categoryManager)
        //{
        //    Console.WriteLine("------------------------------------------");
        //    foreach (var category in categoryManager.GetAll().Data)
        //    {
        //        Console.WriteLine(category.CategoryName);
        //    }
        //    Console.WriteLine("------------------------------------------");
        //    var c = categoryManager.GetCategoryById(1).Data;
        //    Console.WriteLine(c.CategoryName);
        //}

        //private static void ProductTest(ProductManager productManager)
        //{
        //    foreach (var product in productManager.GetAll().Data)
        //    {
        //        Console.WriteLine(product.ProductName);
        //    }
        //    Console.WriteLine("------------------------------------------");
        //    foreach (var product in productManager.GetByCategoryId(1).Data)
        //    {
        //        Console.WriteLine(product.ProductName);
        //    }
        //    Console.WriteLine("------------------------------------------");
        //    foreach (var product in productManager.GetByUnitPrice(50, 100).Data)
        //    {
        //        Console.WriteLine(product.ProductName);
        //    }
        //    Console.WriteLine("------------------------------------------");
        //    foreach (var product in productManager.GetProductDetails().Data)
        //    {
        //        Console.WriteLine($"{product.ProductName} / {product.CategoryName} / {product.UnitsInStock}");
        //    }
        }
    }
}
