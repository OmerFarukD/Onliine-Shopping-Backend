using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entity.Concrete;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<List<Category>> GetAll();
        IDataResult<Category> GetById(int id);

        IDataResult<Category> GetByName(string name);

        IResult DeleteById(int id);
        IResult Update(Category category);
        IResult Add(Category category);
        IResult TransactionalOperation(Category category);
    }
}
