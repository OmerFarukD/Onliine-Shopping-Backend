using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entity.Concrete;

namespace Business.Abstract
{
    public interface IClothesService
    {
        IDataResult<List<Clothes>> GetAll();
        IResult Add(Clothes clothes);

        IResult Delete(Clothes clothes);

        IResult Update(Clothes clothes);

        IDataResult<List<Clothes>> GetAllByStartsWith(string pattern);

        IDataResult<Clothes> GetById(long id);
    }
}
