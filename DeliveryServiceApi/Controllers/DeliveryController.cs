using System;
using System.Linq;
using DeliveryServiceApi.Data;
using DeliveryServiceApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryServiceApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeliveryController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ApplicationDbContext _dbContext;

        public DeliveryController(IOrderService orderService, ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _orderService = orderService;
        }

        [HttpGet("check-status")]
        public IActionResult CheckStatus()
        {
            return Ok("Active");
        }

        [HttpPost("send-order")]
        public IActionResult SendOrder()
        {
            try
            {
                if (_orderService.IsFreeCourierAvailable())
                {
                    return Ok("Order has been sent");
                }

                return NotFound("Availabel courier not found");
            }
            catch (Exception ex)
            {
                return BadRequest("Order rejected");
            }
        }

        [HttpGet("orders-count")]
        public IActionResult GetOrdersCount()
        {
            int ordersCount = _dbContext.Orders.Count();

            return Ok(ordersCount);
        }
    }
}