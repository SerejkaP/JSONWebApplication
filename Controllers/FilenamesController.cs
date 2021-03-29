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
    public class FilenamesController : ControllerBase
    {
        [HttpGet]
        public string filenames(bool correct)
        {
            string json = "";
            JsonDataProvider obj = new JsonDataProvider();
            JsonData jsonData = obj.DeserializeJsonData();
            for( int i = 0; i < jsonData.files.Length; i++)
            {
                if (jsonData.files[i].result == correct)
                {
                    json += Newtonsoft.Json.JsonConvert.SerializeObject(jsonData.files[i].filename);
                }
            }
            return json;
        }
    }
}
