using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BAL_SERVICES.Services;
using DAL_SERVICES.Interface;
using DAL_SERVICES.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApp_EComm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly OrderDetailService _orderDetailService;

        private readonly IRepository<OrderDetail> _orderDetail;

        public OrderDetailController(IRepository<OrderDetail> orderDetail, OrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
            _orderDetail = orderDetail;

        }

        [HttpGet("GetAllOrderDetails")]
        public Object GetAllOrderDetails()
        {
            var data = _orderDetailService.GetAllOrderDetails();
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }

        //Add OrderDetail  
        //[HttpPost("AddCustomer")]
        //public async Task<Object> AddOrderDetail([FromBody] OrderDetail orderDetail)
        //{
        //    try
        //    {
        //        await _orderDetailService.(orderDetail);
        //        return true;
        //    }
        //    catch (Exception)
        //    {

        //        return false;
        //    }
        //}
    }
}