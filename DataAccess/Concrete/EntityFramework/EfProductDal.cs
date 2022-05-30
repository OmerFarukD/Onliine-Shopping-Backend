using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Dtos;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal:EfEntityDal<Product,ShoppingContext>,IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (var context=new ShoppingContext())
            {
                var result = from product in context.Products
                    join color in context.Colors on product.ColorId equals color.ColorId
                    join category in context.Categories on product.CategoryId equals category.CategoryId
                    join image in context.Images on product.ImageId equals image.ImageId
                    select new ProductDetailDto{ProductName = product.ProductName,
                        CategoryName = category.CategoryName,
                        UnitPrice = product.UnitPrice,
                        ColorName = color.ColorName,
                        Description = product.Description,
                        ImagePath = image.ImagePath,
                        UnitsInStock = product.UnitsInStock};
                return result.ToList();
            }
        }

        public List<ProductDetailDto> GetProductDetailsByCategoryId(int id)
        {
            using (var context = new ShoppingContext())
            {
                var result = from product in context.Products
                    join color in context.Colors on product.ColorId equals color.ColorId
                    join category in context.Categories on product.CategoryId equals category.CategoryId
                    join image in context.Images on product.ImageId equals image.ImageId
                    where category.CategoryId == id
                    select new ProductDetailDto
                    {
                        ProductName = product.ProductName,
                        CategoryName = category.CategoryName,
                        UnitPrice = product.UnitPrice,
                        ColorName = color.ColorName,
                        Description = product.Description,
                        ImagePath = image.ImagePath,
                        UnitsInStock = product.UnitsInStock
                    };
                return result.ToList();
            }
        }


    }
}
