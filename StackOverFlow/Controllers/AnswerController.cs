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
    public class AnswerController : ApiController
    {
        private StackContext db = new StackContext();
        public IQueryable<Answer> GetAnswer()
        {
            return db.answer;
        }
        public IHttpActionResult GetAnswer(int id)
        {
            //  db.question.OrderBy("id", true).ToList();
         IQueryable<Answer> answer=(from s in db.answer where s.Questionid == id select s);
            //Answer answer = db.answer.Find(id);
            if (answer == null)
            {
                return NotFound();
            }

            return Ok(answer);
        }
        public HttpResponseMessage PostAnswer(string token, Answer answer)
        {
             string userid = answer.Userid;
           //string userid = "rashid@gmail.com";
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            bool valid = TokenManager.Validate(userid, token);

            if (valid)
            {
                db.answer.Add(answer);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "success");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }


        }
    }
}
