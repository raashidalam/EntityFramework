using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.UI.WebControls;
using StackOverFlow.DAL;
using StackOverFlow.Models;

namespace StackOverFlow.Controllers
{
    public class QuestionController : ApiController
    {
        private StackContext db = new StackContext();
        // GET: api/Question

      // [Queryable]
       public IQueryable<Questions> Getquestion()
        {
            // return db.question;
            return (from s in db.question orderby s.id descending select s);
        }

        // GET: api/Question/5
        //[ResponseType(typeof(Questions))]
        //public IHttpActionResult GetQuestions(int id)
        //{
        //  //  db.question.OrderBy("id", true).ToList();
        //    Questions questions = db.question.Find(id);
        //    if (questions == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(questions);
        //}

        // PUT: api/Question/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutQuestions(int id, Questions questions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != questions.id)
            {
                return BadRequest();
            }

            db.Entry(questions).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Question
        [ResponseType(typeof(Questions))]
        public HttpResponseMessage PostQuestions(string token,Questions questions)
        {
            string userid = questions.Userid;
            ICollection<Tag> tags = questions.tag;
            Console.WriteLine(tags);
            // string userid = "rashid";
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            bool valid = TokenManager.Validate(userid, token);
           
            if(valid)
            {
                db.question.Add(questions);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK,"success");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

           
        }

        // DELETE: api/Question/5
        [ResponseType(typeof(Questions))]
        public IHttpActionResult DeleteQuestions(int id)
        {
            Questions questions = db.question.Find(id);
            if (questions == null)
            {
                return NotFound();
            }

            db.question.Remove(questions);
            db.SaveChanges();

            return Ok(questions);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QuestionsExists(int id)
        {
            return db.question.Count(e => e.id == id) > 0;
        }
    }
}