﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.DTOs;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NordwindContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (NordwindContext context =new NordwindContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId
                             select new ProductDetailDto {ProductId=p.ProductId,ProductName=p.ProductName,CategoryName=c.CategoryName,UnitsInStock=p.UnitsInStock };
                return result.ToList();
            }
        }
    }
}
