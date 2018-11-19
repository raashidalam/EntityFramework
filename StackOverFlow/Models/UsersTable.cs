using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StackOverFlow.Models
{
    public class UsersTable
    {
        [Key]
        public string userid { get; set; }
       // public string Userid { get; internal set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        [MinLength(8)]
        public string password { get; set; }
        //public ICollection<Questions> users { get; set; }
        //public ICollection<Answer> answer { get; set; }
    }
}