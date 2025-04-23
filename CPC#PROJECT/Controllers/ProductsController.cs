using BL.Api;
using BL.Models;
using Microsoft.AspNetCore.Mvc;

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
        public List<BLProduct> Get()
        {
            return products.Get(); 
        }
        [HttpPost("Add")]
        public List<BLProduct> Add(BLProduct p)
        {
            return products.Add(p);
        }
        [HttpPut("Update")]
        public List<BLProduct> Update(BLProduct p)
        {
            return products.Update(p);
        }
        [HttpPut("UpdateAmount")]
        public List<BLProduct> UpdateAmount(int p,int amount)
        {
            return products.UpdateAmount(p,amount);
        }
        [HttpDelete("Delete")]
        public List<BLProduct> Delete(int p)
        {
            return products.DeleteFromList(p);
        }


    }
}
