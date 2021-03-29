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
    public class allDataController : ControllerBase
    {
        [HttpGet]
        public string allData()
        {
            JsonDataProvider obj = new JsonDataProvider();
            JsonData jsonData = obj.DeserializeJsonData();
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(jsonData);
            return json;
        }
    }
}
