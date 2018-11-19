using StackOverFlow.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StackOverFlow.Controllers
{
    public class TagController : ApiController
    {
        private StackContext db = new StackContext();
        [HttpPost]
        public void PostTag()
        {

        }
    }
}
