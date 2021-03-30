using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JSONWebApplication.Models
{
    public class querycheck
    {
        public int total { get; set; }
        public int correct { get; set; }
        public int errors { get; set; }
        public string[] filenames { get; set; }

    }
}
