using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entity.Concrete;
using Entity.Dtos;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<ProductDetailDto>> GetProductDetails();
        IResult Add(Product product);
        IResult Delete(Product product);
        IResult Update(Product product);
        IDataResult<List<ProductDetailDto>> GetProductDetailsByCategoryId(int id);
    }
}
