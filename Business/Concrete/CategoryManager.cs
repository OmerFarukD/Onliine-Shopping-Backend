using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Core.Aspects.Transaction;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class CategoryManager :ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        [CacheAspect]
        [PerformanceAspect]
        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
        }

        [CacheAspect]
        [PerformanceAspect]
        public IDataResult<Category> GetById(int id)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(c => c.CategoryId == id));
        }
        [CacheAspect]
        [PerformanceAspect]
        public IDataResult<Category> GetByName(string name)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(c=>c.CategoryName==name));
        }
        [PerformanceAspect]
        [CacheRemoveAspect("ICategoryService.Get")]
        public IResult DeleteById(int id)
        {
            var result = _categoryDal.Get(c => c.CategoryId == id);

            _categoryDal.Delete(result);
            return new SuccessResult("Id si "+result.CategoryId+" olan kategori silindi.");
        }
        [PerformanceAspect]
        [CacheRemoveAspect("ICategoryService.Get")]
        public IResult Update(Category category)
        {
            _categoryDal.Update(category);
            return new SuccessResult(Messages.CategoryUpdatedMessage);
        }
        [PerformanceAspect]
        [CacheRemoveAspect("ICategoryService.Get")]
        public IResult Add(Category category)
        {
            _categoryDal.Add(category);
            return new SuccessResult(Messages.CategoryAddedMessage);
        }

        [TransactionScopeAspect]
        [PerformanceAspect(25)]
        [CacheRemoveAspect("ICategoryService.Get")]
        public IResult TransactionalOperation(Category category)
        {
            _categoryDal.Update(category);
            _categoryDal.Add(category);
            return new SuccessResult(Messages.CategoryUpdatedMessage);
        }
    }
}
