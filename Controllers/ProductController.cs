using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BAL_SERVICES.Services;
using DAL_SERVICES.Interface;
using DAL_SERVICES.Models;
using DAL_SERVICES.Pagination_Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApp_EComm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        private readonly IRepository<Product> _product;

        public ProductController(IRepository<Product> product, ProductService productService)
        {
            _productService = productService;
            _product = product;

        }

        [HttpGet("GetAllProducts")]
        public Object GetAllProducts([FromQuery] ProductParameters productParameters)
        {
            var data = _productService.GetAllProductsPaged(productParameters);
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }

        //Add Person  
        [HttpPost("AddProduct")]
        public async Task<Object> AddProduct([FromBody] Product product)
        {
            try
            {
                await _productService.AddProduct(product);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        //Update Person  
        [HttpPut("UpdateProduct")]
        public bool UpdateProduct(Product Object)
        {
            try
            {
                _productService.UpdateProduct(Object);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Delete Product  
        [HttpDelete("DeleteProduct")]
        public bool DeleteMerchant(int id)
        {
            try
            {
                _productService.DeleteProduct(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}