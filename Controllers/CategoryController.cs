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
using WebApp_EComm.ResponseModels;

namespace WebApp_EComm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _categoryService;

        private readonly IRepository<Category> _category;

        public CategoryController(IRepository<Category> Category, CategoryService CategoryService)
        {
            _categoryService = CategoryService;
            _category = Category;

        }

        [HttpGet("GetAllCatogories")]
        public Object GetAllCategories()
        {
            var data = _categoryService.GetAllCategories();
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }


        //Add Category 
        [HttpPost("AddCategory")]
        public async Task<DefaultResponse> AddCategory([FromBody] Category category)
        {
            DefaultResponse resp = new DefaultResponse();
            try
            {
                var newCategory = await _categoryService.AddCategory(category);
                if(newCategory != null)
                {
                    resp.ResponseCode = "00";
                    resp.ResponseMessage = String.Format("Category {0}", ModelAction.ModelCreated);
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
               // return false;
            }
        }

        //Update Category  
        [HttpPut("UpdateCategory")]
        public DefaultResponse UpdateCategory(Category Object)
        {
            DefaultResponse resp = new DefaultResponse();
            try
            {
                var updateCategory = _categoryService.UpdateCategory(Object);
                if (updateCategory == true)
                {
                    resp.ResponseCode = "00";
                    resp.ResponseMessage = String.Format("Category {0}", ModelAction.ModelUpdated);
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
        [HttpDelete("DeleteCategory")]
        public DefaultResponse DeleteCategory(int id)
        {
            DefaultResponse resp = new DefaultResponse();
            try
            {
                var deleteCustomer = _categoryService.DeleteCategory(id);
                if (deleteCustomer == true)
                {
                    resp.ResponseCode = "00";
                    resp.ResponseMessage = String.Format("Category {0}", ModelAction.ModelDeleted);
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