using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BAL_SERVICES.Services;
using DAL_SERVICES.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp_EComm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
                       
        }

        //Add Order  
        [HttpPost("AddOrder")]
        public async Task<Object> AddOrder([FromBody] Order order)
        {
            try
            {
                await _orderService.AddOrder(order);
                return true;
            }
            catch (Exception ee)
            {
                string tst = ee.Message;
                return false;
            }
        }

    }
}