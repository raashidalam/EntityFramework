using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StackOverFlow.Models
{
    public class Tag
    {
        public int id { get; set; }
        public string tag{ get; set; }
        public Questions Question { get; set; }
        public int Questionid { get; set; }
    }
}