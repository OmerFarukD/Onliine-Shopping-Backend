using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace AngularWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private IImageService _imageService;

        public ImagesController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] IFormFile formFile,Image image)
        {
            var data = _imageService.Add(formFile, image);
            if (!data.Success)
            {
                return BadRequest(data.Message);
            }

            return Ok(data);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Image image)
        {
            var data = _imageService.Delete(image);
            if (!data.Success)
            {
                return BadRequest(data.Message);
            }

            return Ok(data);
        }

        [HttpPatch("update")]
        public IActionResult Update([FromForm] IFormFile file,Image image)
        {
            var result = _imageService.Update(file,image);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _imageService.GetAll();
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpGet("getallbyproductid")]
        public IActionResult GetAllByProductId(int productId)
        {
            var result = _imageService.GetAllByProductId(productId);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpGet("getbyimageid")]
        public IActionResult GetByImageId(int id)
        {
            var result = _imageService.GetById(id);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }
    }
}
