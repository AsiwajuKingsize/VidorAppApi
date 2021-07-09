using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApp_EComm.ResponseModels;

namespace WebApp_EComm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private IConfiguration configuration;
        private static readonly HttpClient client = new HttpClient();

        public PaymentController(IConfiguration iConfig)
        {
            configuration = iConfig;
        }

        private static async Task ProcessRepositories()
        {
        }
        public async Task<DefaultResponse> ProcessPayment()
        {
            DefaultResponse resp = new DefaultResponse();
            string url = configuration.GetValue<string>("AppSettings:PayStackUrl");
            try
            {
                
                return resp;
                //return true;
            }
            catch (Exception ee)
            {
                resp.ResponseCode = "02";
                resp.ResponseMessage = ee.Message;
                return resp;
                // return false;
            }
        }

    }
}