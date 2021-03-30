using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace JSONWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class newErrorsController : ControllerBase
    {
        [HttpPost]
        public async Task newErrorsAsync([FromBody] string value)
        {
            JsonData jsonData = new JsonData();
            jsonData = JsonConvert.DeserializeObject<JsonData>(value);
            string path = @"JSONWebApplication\JsonFiles\";
            if (jsonData.files != null || jsonData.scan != null)
            {
                string fullpath = DateTime.Today.ToString();
                using FileStream fstream = new FileStream($"{path}\\" + fullpath + ".json", FileMode.Create);
                byte[] array = System.Text.Encoding.Default.GetBytes(value);
                await fstream.WriteAsync(array, 0, array.Length);
            }
        }
    }
}
