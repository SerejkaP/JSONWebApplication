using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JSONWebApplication
{
    public class JsonDataProvider
    {
        public JsonData DeserializeJsonData()
        {
            JsonData obj = JsonConvert.DeserializeObject<JsonData>(System.IO.File.ReadAllText("data.json"));
            return obj;
        }
    }
}
