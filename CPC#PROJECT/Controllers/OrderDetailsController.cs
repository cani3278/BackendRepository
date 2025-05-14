using BL.Api;
using BL.Models;
using Microsoft.AspNetCore.Mvc;

namespace CPC_PROJECT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController:ControllerBase
    {
        IBLOrderDetails orderDetails;// = new BlPatientService();
        public OrderDetailsController(IBL manager)
        {
            orderDetails = manager.OrderDetails;
        }
        // להחזיר רשימת כל ההזמנות
        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            return Ok(orderDetails.GetAll());
        }

        [HttpGet("GetDetailsForOrder/{id}")]
        public IActionResult GetByCustomer(int id)
        {
            return Ok(orderDetails.GetForOrderId(id));
        }
        





    }
}
