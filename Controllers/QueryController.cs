using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace JSONWebApplication.Controllers
{

    public class querycheck
    {
        public int total  { get; set;}
        public int correct { get; set; }
        public int errors { get; set; }
        public string[] filenames { get; set; }

    }

    [Route("api/[controller]")]
    [ApiController]
    public class QueryController : ControllerBase
    {
        [HttpGet("check")]
        public string indexError(int index)
        {
            JsonDataProvider obj = new JsonDataProvider();
            JsonData jsonData = obj.DeserializeJsonData();
            querycheck qobj = new querycheck();
            int qtotal=0;
            int qcorrect=0;
            int qerrors=0;
            string json = "";
            for (int i = 0; i < jsonData.files.Length; i++)
            {
                if (jsonData.files[i].filename.IndexOf("q")==0 && jsonData.files[i].filename.IndexOf("u")==1 && jsonData.files[i].filename.IndexOf("e")==2 && jsonData.files[i].filename.IndexOf("r")==3 && jsonData.files[i].filename.IndexOf("y")==4 && jsonData.files[i].filename.IndexOf("_")==5)
                {
                    qtotal++;
                    if (jsonData.files[i].result == true) qcorrect++;
                    if (jsonData.files[i].result == false)
                    {
                        qerrors++;
                    }
                }
            }
            string[] qfilenames = new string[qerrors];
            qerrors = 0;
            for (int i = 0; i < jsonData.files.Length; i++)
            {
                if (jsonData.files[i].filename.IndexOf("q") == 0 && jsonData.files[i].filename.IndexOf("u") == 1 && jsonData.files[i].filename.IndexOf("e") == 2 && jsonData.files[i].filename.IndexOf("r") == 3 && jsonData.files[i].filename.IndexOf("y") == 4 && jsonData.files[i].filename.IndexOf("_") == 5)
                {
                    if (jsonData.files[i].result == false)
                    {
                        if (qobj.filenames == null)
                        {
                            qfilenames[qerrors] = jsonData.files[i].filename;
                            qerrors++;
                        }
                    }
                }
            }
            qobj.total = qtotal;
            qobj.correct = qcorrect;
            qobj.errors = qerrors;
            if (qerrors > 0) qobj.filenames = qfilenames;
            json = JsonConvert.SerializeObject(qobj);
            return json;
        }
    }
}
