using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

public class Program
{
    public static void Main(string[] args)
    {
        //ProductTest();
        //CategoryTest();
        ProductTestt();

    }

    private static void CategoryTest()
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoyDal());
        foreach (var category in categoryManager.GetAll().Data)
        {
            Console.WriteLine(category.CategoryName);
        }
    }

    private static void ProductTest()
    {
        ProductManager productManager = new ProductManager(new EfProductDal());
        foreach (var product in productManager.GetAllByCategoryId(2).Data)
        {
            Console.WriteLine(product.ProductName);
        }
    }
    private static void ProductTestt()
    {
        ProductManager productManager = new ProductManager(new EfProductDal());
        var result = productManager.GetProductDetail();
        if (result.Success==true)
        {
            foreach (var product in result.Data)
            {
                Console.WriteLine(product.ProductName + " / " + product.CategoryName);
            }
        }
        else
        {
            Console.WriteLine(result.Message);
        }
        
    }
}