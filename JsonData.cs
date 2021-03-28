using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JSONWebApplication
{
    //Классы для данных из data.json
    public class Rootobject
    {
        public Scan scan { get; set; }
        public File[] files { get; set; }
    }

    public class Scan
    {
        public string db { get; set; }
        public int errorCount { get; set; }
        public DateTime scanTime { get; set; }
        public string server { get; set; }
    }

    public class File
    {
        public string filename { get; set; }
        public bool result { get; set; }
        public Error[] errors { get; set; }
        public DateTime scantime { get; set; }
    }

    public class Error
    {
        public string module { get; set; }
        public int ecode { get; set; }
        public string error { get; set; }
    }
}

