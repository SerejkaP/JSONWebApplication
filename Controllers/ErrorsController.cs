using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JSONWebApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace JSONWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorsController : ControllerBase
    {

        [HttpGet]
        public string errors()
        {
            JsonDataProvider obj = new JsonDataProvider();
            JsonData jsonData = obj.DeserializeJsonData();
            ErrorsModel model = new ErrorsModel();
            int errorsCount = jsonData.scan.errorCount;
            List<string> errorobject = new List<string>();
            for (int i = 0; i < jsonData.files.Length; i++)
            {
                if (jsonData.files[i].result == false)
                {
                    model.filename = jsonData.files[i].filename;
                    List<string> ind = new List<string>();
                    for (int j = 0; j < jsonData.files[i].errors.Length; j++)
                    {
                        ind.Add(jsonData.files[i].errors[j].error);
                    }
                    model.error = ind.ToArray<string>();
                    errorobject.Add(JsonConvert.SerializeObject(model));
                }
            }
            string[] json = new string[errorobject.Count];
            json = errorobject.ToArray();
            return String.Join(",",json);
        }

        [HttpGet("count")]
        public string count()
        {
            JsonDataProvider obj = new JsonDataProvider();
            JsonData jsonData = obj.DeserializeJsonData();
            string json = jsonData.scan.errorCount.ToString();
            return json;
        }

        [HttpGet("{index}")]
        public string indexError(int index)
        {
            JsonDataProvider obj = new JsonDataProvider();
            JsonData jsonData = obj.DeserializeJsonData();
            ErrorsModel model = new ErrorsModel();
            int errorsCount = jsonData.scan.errorCount;
            List<string> errorobject = new List<string>();
            string json="";
            for (int i = 0; i < jsonData.files.Length; i++)
            {
                if (jsonData.files[i].result == false)
                {
                    model.filename = jsonData.files[i].filename;
                    List<string> ind = new List<string>();
                    for (int j = 0; j < jsonData.files[i].errors.Length; j++)
                    {
                        ind.Add(jsonData.files[i].errors[j].error);
                    }
                    model.error = ind.ToArray<string>();
                    errorobject.Add(JsonConvert.SerializeObject(model));
                }
            }
            for (int i = 0; i < errorobject.Count; i++)
            {
                if (index == i) json = errorobject.ToArray()[i];
            }
            return json;
        }

    }
}
