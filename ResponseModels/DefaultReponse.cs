using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_EComm.ResponseModels
{
    public static class ModelAction
    {
        public const string ModelCreated = "Successfully created";
        public const string ModelUpdated = "Successfully modified";
        public const string ModelDeleted = "Successfully deleted";
        public const string ModelFailure = "Something went wrong";

    }
    public class DefaultResponse
    {
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
    }


    
}
