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
using BAL_SERVICES.Helpers;
using WebApp_EComm.ResponseModels;

namespace WebApp_EComm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;

        private readonly IRepository<Customer> _customer;

        private readonly SecurityHelper _securityHelper;
        public CustomerController(IRepository<Customer> customer, CustomerService customerService, SecurityHelper securityHelper)
        {
            _customerService = customerService;
            _customer = customer;
            _securityHelper = securityHelper;

        }

        [HttpGet("GetAllCustomers")]
        public Object GetAllCustomers()
        {
            var data = _customerService.GetAllCustomers();
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }

        //Add Customer  
        [HttpPost("AddCustomer")]
        public async Task<DefaultResponse> AddCustomer([FromBody] Customer customer)
        {
            DefaultResponse resp = new DefaultResponse();
            try
            {
                //string vSalt = SecurityHelper.GenerateSalt();
                //customer.Password = SecurityHelper.HashPassword(customer.Password,vSalt);
                var newCustomer = await _customerService.AddCustomer(customer);
                if (newCustomer != null)
                {
                    resp.ResponseCode = "00";
                    resp.ResponseMessage = String.Format("Customer {0}", ModelAction.ModelCreated);
                }
                else
                {
                    resp.ResponseCode = "01";
                    resp.ResponseMessage = ModelAction.ModelFailure;
                }
                return resp;
                //return true;
            }
            catch (Exception ee)
            {
                resp.ResponseCode = "02";
                resp.ResponseMessage = ee.Message;
                return resp;
                //return false;
            }
        }

        //Update Person  
        [HttpPut("UpdateCustomer")]
        public DefaultResponse UpdateCustomer(Customer Object)
        {
            DefaultResponse resp = new DefaultResponse();
            try
            {
                var updateCustomer = _customerService.UpdateCustomer(Object);
                if (updateCustomer == true)
                {
                    resp.ResponseCode = "00";
                    resp.ResponseMessage = String.Format("Customer {0}", ModelAction.ModelUpdated);
                }
                else
                {
                    resp.ResponseCode = "01";
                    resp.ResponseMessage = ModelAction.ModelFailure;
                }
                return resp;
               // return true;
            }
            catch (Exception ee)
            {
                resp.ResponseCode = "02";
                resp.ResponseMessage = ee.Message;
                return resp;
                //return false;
            }
        }

        //Delete Product  
        [HttpDelete("DeleteCustomer")]
        public DefaultResponse DeleteCustomer(int id)
        {
            DefaultResponse resp = new DefaultResponse();
            try
            {
                var deleteCustomer =_customerService.DeleteCustomer(id);
                if (deleteCustomer == true)
                {
                    resp.ResponseCode = "00";
                    resp.ResponseMessage = String.Format("Customer {0}", ModelAction.ModelDeleted);
                }
                else
                {
                    resp.ResponseCode = "01";
                    resp.ResponseMessage = ModelAction.ModelFailure;
                }
                return resp;
                //return true;
            }
            catch (Exception ee)
            {
                resp.ResponseCode = "02";
                resp.ResponseMessage = ee.Message;
                return resp;
                //return false;
            }
        }
    }
}