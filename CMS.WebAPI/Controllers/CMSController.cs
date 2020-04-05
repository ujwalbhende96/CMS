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
using CMS.WebAPI.Models;

namespace CMS.WebAPI.Controllers
{
    public class CMSController : ApiController
    {
        private CMSEntities db = new CMSEntities();

        // GET: api/CMS
        public IQueryable<ContactInformation> GetContactInformations()
        {
            return db.ContactInformations;
        }

        // GET: api/CMS/5
        [ResponseType(typeof(ContactInformation))]
        public IHttpActionResult GetContactInformation(int id)
        {
            ContactInformation contactInformation = db.ContactInformations.Find(id);
            if (contactInformation == null)
            {
                return NotFound();
            }

            return Ok(contactInformation);
        }

        // PUT: api/CMS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutContactInformation(int id, ContactInformation contactInformation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contactInformation.Id)
            {
                return BadRequest();
            }

            db.Entry(contactInformation).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactInformationExists(id))
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

        // POST: api/CMS
        [ResponseType(typeof(ContactInformation))]
        public IHttpActionResult PostContactInformation(ContactInformation contactInformation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ContactInformations.Add(contactInformation);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = contactInformation.Id }, contactInformation);
        }

        // DELETE: api/CMS/5
        [ResponseType(typeof(ContactInformation))]
        public IHttpActionResult DeleteContactInformation(int id)
        {
            ContactInformation contactInformation = db.ContactInformations.Find(id);
            if (contactInformation == null)
            {
                return NotFound();
            }

            db.ContactInformations.Remove(contactInformation);
            db.SaveChanges();

            return Ok(contactInformation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContactInformationExists(int id)
        {
            return db.ContactInformations.Count(e => e.Id == id) > 0;
        }
    }
}