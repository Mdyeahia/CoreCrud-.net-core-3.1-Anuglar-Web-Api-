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
    public class ProductController : Controller
    {
        public readonly IProduct _product;
        public ProductController(IProduct product)
        {
            _product = product;
        }
        [HttpGet]
        [Route("AllProduct")]
        public async Task<ActionResult> Gets() => Ok(await _product.Gets());
        [HttpGet]
        [Route("Product/{{Id}}")]
        public async Task<ActionResult> Get(int id) => Ok(await _product.Get(id));
        [Route("AddProduct")]
        [HttpPost]
        public async Task<ActionResult> Add(Product product)
        {
            var data=await _product.AddProduct(product);
            if (data.Id == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            return Ok(JsonConvert.SerializeObject("Added Successfully"));
        }
        [Route("UpdateProduct")]
        [HttpPost]
        public async Task<ActionResult> update(Product product) => Ok(await _product.UpdateProduct(product));
        [Route("DeleteProduct/{{Id}}")]
        [HttpDelete]
        public  ActionResult Delete(int id) => Ok( _product.Delete(id));
    }
}
