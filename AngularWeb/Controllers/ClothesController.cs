using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AngularWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClothesController : ControllerBase
    {
        private IClothesService _clothesService;

        public ClothesController(IClothesService clothesService)
        {
            _clothesService = clothesService;

        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _clothesService.GetAll();
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(long id)
        {
            var result = _clothesService.GetById(id);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Clothes clothes)
        {
            var result = _clothesService.Add(clothes);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(Clothes clothes)
        {
            var result = _clothesService.Delete(clothes);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpPatch("update")]
        public IActionResult Update(Clothes clothes)
        {
            var result = _clothesService.Update(clothes);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpGet("getallbystartswith")]
        public IActionResult GetAllByStartsWith(string pattern)
        {
            var result = _clothesService.GetAllByStartsWith(pattern);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }
        public IActionResult 
    }

}
