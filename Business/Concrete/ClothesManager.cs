using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Caching;
using Core.Aspects.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class ClothesManager :IClothesService
    {
        private IClothesDal _clothesDal;

        public ClothesManager(IClothesDal clothesDal)
        {
            _clothesDal = clothesDal;
        }
        [CacheAspect]
        public IDataResult<List<Clothes>> GetAll()
        {
            return new SuccessDataResult<List<Clothes>>(_clothesDal.GetAll());
        }

        [ValidationAspect(typeof(ClothesValidator))]
        [CacheRemoveAspect("IClothesService.Get")]
        public IResult Add(Clothes clothes)
        {
            _clothesDal.Delete(clothes);
            return new SuccessResult(Messages.ClothesAddMessage);
        }

        [CacheRemoveAspect("IClothesService.Get")]
        public IResult Delete(Clothes clothes)
        {
            _clothesDal.Delete(clothes);
            return new SuccessResult(Messages.ClothesDeleteMessage);
        }

        [CacheRemoveAspect("IClothesService.Get")]
        public IResult Update(Clothes clothes)
        {
            _clothesDal.Update(clothes);
            return new SuccessResult(Messages.ClothesUpdateMessage);
        }

        [CacheAspect]
        public IDataResult<List<Clothes>> GetAllByStartsWith(string pattern)
        {
            return new SuccessDataResult<List<Clothes>>(_clothesDal.GetAll(c => c.ClothesName.StartsWith(pattern)));
        }

        [CacheAspect]
        public IDataResult<Clothes> GetById(long id)
        {
            return new SuccessDataResult<Clothes>(_clothesDal.Get(c => c.Id == id));
        }
    }
}
