using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StackOverFlow.Models
{
    public class Questions
    {
        [Key]
        public int id { get; set; }
        public string questionTitle { get; set; }
        public string questionBody { get; set; }
        
    //    [ForeignKey("UserTable")]
           public UsersTable User { get; set; }
           public string Userid { get; set; }
     



        public ICollection<Tag> tag { get; set; }

    }
}