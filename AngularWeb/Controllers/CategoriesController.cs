using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AngularWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _categoryService.GetAll();
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _categoryService.GetById(id);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }
        [HttpGet("getbyname")]
        public IActionResult GetByName(string name)
        {
            var result = _categoryService.GetByName(name);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }
        [HttpDelete("deletebyid")]
        public IActionResult DeleteById(int id)
        {
            var res = _categoryService.DeleteById(id);
            if (!res.Success)
            {
                return BadRequest(res.Message);
            }

            return Ok(res);
        }

        [HttpPost("update")]
        public IActionResult Update(Category category)
        {
            var result = _categoryService.Update(category);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Category category)
        {
            var result = _categoryService.Add(category);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);
        }

        [HttpPost("transactionscope")]
        public IActionResult TransactionalOperation(Category category)
        {
            return Ok(_categoryService.TransactionalOperation(category));
        }




    }
}
