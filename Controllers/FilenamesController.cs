using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace JSONWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilenamesController : ControllerBase
    {
        [HttpGet]
        public string filenames(bool correct)
        {
            JsonDataProvider obj = new JsonDataProvider();
            JsonData jsonData = obj.DeserializeJsonData();
            List<string> files = new List<string>();
            for( int i = 0; i < jsonData.files.Length; i++)
            {
                if (jsonData.files[i].result == correct)
                {
                    files.Add(JsonConvert.SerializeObject(jsonData.files[i].filename));
                }
            }
            return String.Join(",", files.ToArray());
        }
    }
}
