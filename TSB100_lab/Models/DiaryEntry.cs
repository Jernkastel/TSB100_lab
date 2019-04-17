using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TSB100_lab.Models
{
    public class DiaryEntry
    {
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public string Entry { get; set; }
        public bool Importance { get; set; }
    }
}