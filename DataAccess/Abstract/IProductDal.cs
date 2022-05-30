using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.Abstract;
using Entity.Concrete;
using Entity.Dtos;

namespace DataAccess.Abstract
{
    public interface IProductDal :IEntityDal<Product>
    {
        List<ProductDetailDto> GetProductDetails();
        List<ProductDetailDto> GetProductDetailsByCategoryId(int id);
    }
}
