using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StackOverFlow.Models
{
    public class Answer
    {
         [Key]
        public int Answerid { get; set; }
        public string answer { get; set; }

        //[ForeignKey("UserTable")]
        public Questions Question { get; set; }
        public int Questionid { get; set; }

        public UsersTable User { get; set; }
        public string Userid { get; set; }
       

        //[ForeignKey("Questions")]
      

        // public ICollection<UsersTable> Users { get; set; }





    }
}