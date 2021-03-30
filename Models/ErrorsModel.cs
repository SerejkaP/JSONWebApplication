using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JSONWebApplication.Models
{
    public class ErrorsModel
    {
        public string filename { get; set; }
        public string[] error { get; set; }
    }
}
