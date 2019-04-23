using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TSB100_lab.Models
{
    public class RESTServicePosts
    {
        public int Id { get; set; }

        public string Author { get; set; }

        public string Post { get; set; }

        public bool Important { get; set; }
    }
}