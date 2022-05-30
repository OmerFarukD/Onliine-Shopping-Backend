using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface IImageService
    {
        IResult Add(IFormFile file, Image image);
        IResult Delete(Image image);
        IResult Update(IFormFile file, Image image);
        IDataResult<List<Image>> GetAll();
        IDataResult<List<Image>> GetAllByProductId(int id);

        IDataResult<Image> GetById(int id);
    }
}
