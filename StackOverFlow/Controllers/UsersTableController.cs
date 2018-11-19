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
using StackOverFlow.DAL;
using StackOverFlow.Models;

namespace StackOverFlow.Controllers
{
    public class UsersTableController : ApiController
    {
        private StackContext db = new StackContext();

        //  GET: api/UsersTable
        public IQueryable<UsersTable> GetuserTables()
        {
            return db.userTables;
        }

        // GET: api/UsersTable/5
        // [ResponseType(typeof(UsersTable))]
       //[HttpPost]
       // public HttpResponseMessage Users(UsersTable user)
       // {
       //     var userid = user.userid;
       //     var password = user.password;
       //     UsersTable usersTable = db.userTables.FirstOrDefault(m => m.userid == userid && m.password == password);
       //     if (usersTable == null)
       //     {
       //         return Request.CreateResponse(HttpStatusCode.Unauthorized);
       //     }


       //     return Request.CreateResponse(HttpStatusCode.OK);
       // }

        // PUT: api/UsersTable/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUsersTable(string id, UsersTable usersTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usersTable.userid)
            {
                return BadRequest();
            }

            db.Entry(usersTable).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersTableExists(id))
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

      //  POST: api/UsersTable
       //[ResponseType(typeof(UsersTable))]
        public HttpResponseMessage PostUsersTable(UsersTable usersTable)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.userTables.Add(usersTable);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (UsersTableExists(usersTable.userid))
                {
                    return Request.CreateResponse(HttpStatusCode.Conflict, "User Already Exist");
                }
                else
                {
                    throw;
                }
            }

            //return CreatedAtRoute("DefaultApi", new { id = usersTable.userid }, usersTable);
            return Request.CreateResponse(HttpStatusCode.OK, "Success...");
        }

        // DELETE: api/UsersTable/5
        [ResponseType(typeof(UsersTable))]
        public IHttpActionResult DeleteUsersTable(string id)
        {
            UsersTable usersTable = db.userTables.Find(id);
            if (usersTable == null)
            {
                return NotFound();
            }

            db.userTables.Remove(usersTable);
            db.SaveChanges();

            return Ok(usersTable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsersTableExists(string id)
        {
            return db.userTables.Count(e => e.userid == id) > 0;
        }
    }
}