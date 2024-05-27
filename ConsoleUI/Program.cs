using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

public class Program
{
    public static void Main(string[] args)
    {
        ProductManager productManager = new ProductManager(new InMemoryProductDal());
        foreach (Product product in productManager.GetAll())
        {
            Console.WriteLine(product.ProductName);
        }
    }
}