using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using BAL_SERVICES.Services;
using DAL_SERVICES.Interface;
using DAL_SERVICES.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApp_EComm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MerchantController : ControllerBase
    {
        private readonly MerchantService _merchantService;

        private readonly IRepository<Merchant> _merchant;

        public MerchantController(IRepository<Merchant> Merchant, MerchantService MerchantService)
        {
            _merchantService = MerchantService;
            _merchant = Merchant;

        }

        [HttpGet("GetAllMerchants")]
        public Object GetAllMerchants()
        {
            var data = _merchantService.GetAllMerchants();
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }

        //Add Person  
        [HttpPost("AddMerchant")]
        public async Task<Object> AddMerchant([FromBody] Merchant merchant)
        {
            try
            {
                await _merchantService.AddMerchant(merchant);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        //Update Person  
        [HttpPut("UpdateMerchant")]
        public bool UpdateMerchant(Merchant Object)
        {
            try
            {
                _merchantService.UpdateMerchant(Object);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Delete Merchant  
        [HttpDelete("DeleteMerchant")]
        public bool DeleteMerchant(int id)
        {
            try
            {
                _merchantService.DeleteMerchant(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}