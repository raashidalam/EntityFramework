using StackOverFlow.DAL;
using StackOverFlow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StackOverFlow.Controllers
{
    public class LoginController : ApiController
    {
        private StackContext db = new StackContext();
        [HttpPost]
        public HttpResponseMessage Loginuser(UsersTable user)
        {
            var userid = user.userid;
            var password = user.password;
            Console.WriteLine(password);
            UsersTable usersTable = db.userTables.FirstOrDefault(m => m.userid == userid && m.password == password);
            if (usersTable == null)
                return Request.CreateResponse(HttpStatusCode.NotFound,
                     "The user was not found.");
            //bool credentials = u.Password.Equals(user.password);
            //if (!credentials) return Request.CreateResponse(HttpStatusCode.Forbidden,
            //    "The username/password combination was wrong.");
            return Request.CreateResponse(HttpStatusCode.OK,
                 TokenManager.GenerateToken(user.userid));
        }
       // [HttpPost]
        //public bool Validate(string username,string token)
        //{
        //    //bool exists = new UserRepository().GetUser(username) != null;
        //    //if (!exists) return Request.CreateResponse(HttpStatusCode.NotFound,
        //    //     "The user was not found.");
        //    string tokenUsername = TokenManager.ValidateToken(token);
        //    if (username.Equals(tokenUsername))
        //        return true;
        //    return false;
        //}
    }
}
