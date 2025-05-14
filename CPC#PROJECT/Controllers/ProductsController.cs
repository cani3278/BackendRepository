using BL.Api;
using BL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CPC_PROJECT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IBLProducts products;
        public ProductsController(IBL manager)
        {
            products = manager.Products;
        }

        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            return Ok(products.Get());
        }

        [HttpGet("GetByID/{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(products.GetByID(id));
        }

        [HttpPost("Add")]
        public IActionResult Add(BLProduct p)
        {
           return Ok(products.Add(p).Result);
        }
       
        [HttpPut("Update")]
        public IActionResult Update(BLProduct p)
        {
            return Ok(products.Update(p).Result);
        }

        [HttpPut("UpdateAmount")]
        public IActionResult UpdateAmount(int p,int amount)
        {
            return Ok(products.UpdateAmount(p, amount).Result);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int p)
        {
            return Ok(products.DeleteFromList(p).Result);
        }


    }
}
