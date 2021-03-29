using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JSONWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorsController : ControllerBase
    {
       /* [HttpGet]
        public string errors()
        {
            string json = "";
            JsonDataProvider obj = new JsonDataProvider();
            JsonData jsonData = obj.DeserializeJsonData();
            for (int i = 0; i < jsonData.files.Length; i++)
            {
                if (jsonData.files[i].result == false)
                {
                    
                }
            }
            return json;
        }*/

        [HttpGet("count")]
        public string count()
        {
            JsonDataProvider obj = new JsonDataProvider();
            JsonData jsonData = obj.DeserializeJsonData();
            string json = jsonData.scan.errorCount.ToString();
            return json;
        }
    }
}
