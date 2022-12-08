using CoreCrud.Models;
using CoreCrud.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace CoreCrud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        public readonly ICategory _category;
        public CategoryController(ICategory category)
        {
            _category = category;
        }
        [HttpGet]
        [Route("AllCategory")]
        public async Task<ActionResult> Gets() => Ok(await _category.Gets());
        [HttpGet]
        [Route("Category/{{Id}}")]
        public async Task<ActionResult> Get(int id) => Ok(await _category.Get(id));
        [Route("AddCategory")]
        [HttpPost]
        public async Task<ActionResult> Add(Category category)
        {
            var data=await _category.AddCategory(category);
            if (data.Id == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            return Ok(JsonConvert.SerializeObject("Added Successfully"));
        }
        [Route("UpdateCategory")]
        [HttpPost]
        public async Task<ActionResult> update(Category category) => Ok(await _category.UpdateCategory(category));
        [Route("DeleteCategory/{{Id}}")]
        [HttpDelete]
        public  ActionResult Delete(int id) => Ok( _category.Delete(id));
    }
}
