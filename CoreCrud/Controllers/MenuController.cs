using CoreCrud.Models;
using CoreCrud.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        public readonly IMenu _menu;
        public MenuController(IMenu menu)
        {
            _menu = menu;
        }

        [HttpGet]
        [Route("AllMenu")]
        public async Task<ActionResult> getAllParentMenu() => Ok(await _menu.getmenu());
    }
}
