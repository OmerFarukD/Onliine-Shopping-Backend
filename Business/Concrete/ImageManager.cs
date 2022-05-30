using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class ImageManager :IImageService
    {
        private IImageDal _imageDal;
        private IFileHelper _fileHelper;
        public ImageManager(IImageDal imageDal,IFileHelper fileHelper)
        {
            _imageDal = imageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile file, Image image)
        {
            image.ImagePath = _fileHelper.Upload(file, PathConstants.ImagesPath);
            image.Date = DateTime.Now;
            _imageDal.Add(image);
            return new SuccessResult();
        }

        public IResult Delete(Image image)
        {
            _fileHelper.Delete(PathConstants.ImagesPath + image.ImagePath);
            _imageDal.Delete(image);
            return new SuccessResult();
        }

        public IResult Update(IFormFile file, Image image)
        {
            image.ImagePath = _fileHelper.Update(file, PathConstants.ImagesPath + image.ImagePath, PathConstants.ImagesPath);
            _imageDal.Update(image);
            return new SuccessResult();
        }

        public IDataResult<List<Image>> GetAll()
        {
            return new SuccessDataResult<List<Image>>(_imageDal.GetAll());
        }

        public IDataResult<List<Image>> GetAllByProductId(int id)
        {
            return new SuccessDataResult<List<Image>>(_imageDal.GetAll(i=>i.ProductId==id));
        }

        public IDataResult<Image> GetById(int id)
        {
            return new SuccessDataResult<Image>(_imageDal.Get(i=>i.ImageId==id));
        }
    }
}
