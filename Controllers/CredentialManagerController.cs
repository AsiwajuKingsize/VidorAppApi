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
    public class CredentialManagerController : ControllerBase
    {
        private readonly LogInService _LogInService;
        public CredentialManagerController(LogInService logInService)
        {
            _LogInService = logInService;
        }


        [HttpPost("isCustomerCredentialValid")]
        public bool isCustomerCredentialValid(Credential credential)
        {
            bool result = false;

            result = _LogInService.confirmCustomerCredential(credential.Id, credential.Password);

            return result;
        }


    }
}