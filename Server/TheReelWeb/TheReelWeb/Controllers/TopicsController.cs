using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using TheReelWeb.Models;

namespace TheReelWeb.Controllers
{
    public class TopicsController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/Topics
        public IQueryable<Topic> GetTopics()
        {
            return db.Topic;
        }

        // GET: api/Topics/5
        [ResponseType(typeof(Topic))]
        public async Task<IHttpActionResult> GetTopics(int id)
        {
            Topic topic = await db.Topic.FindAsync(id);
            if (topic == null)
            {
                return NotFound();
            }

            return Ok(topic);
        }

        // PUT: api/Topics/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUsers(int id, Topic topic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != topic.id)
            {
                return BadRequest();
            }

            db.Entry(topic).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TopicExists(id))
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

        // POST: api/Topics
        [ResponseType(typeof(Topic))]
        public async Task<IHttpActionResult> PostTopics(Topic topic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Topic.Add(topic);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = topic.id }, topic);
        }

        // DELETE: api/Topics/5
        [ResponseType(typeof(Topic))]
        public async Task<IHttpActionResult> DeleteTopics(int id)
        {
            Topic topic = await db.Topic.FindAsync(id);
            if (topic == null)
            {
                return NotFound();
            }

            db.Topic.Remove(topic);
            await db.SaveChangesAsync();

            return Ok(topic);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TopicExists(int id)
        {
            return db.Topic.Count(e => e.id == id) > 0;
        }
    }
}
