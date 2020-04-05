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
        private CMSEntities cmsEntities = new CMSEntities();
        
        // GET: api/CMS
        public IQueryable<ContactList> GetContactLists()
        {
            return cmsEntities.ContactLists;
        }

        // GET: api/CMS/5
        [ResponseType(typeof(ContactList))]
        public IHttpActionResult GetContactList(int id)
        {
            ContactList ContactList = cmsEntities.ContactLists.Find(id);
            if (ContactList == null)
            {
                return NotFound();
            }

            return Ok(ContactList);
        }

        // PUT: api/CMS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutContactList(int id, ContactList ContactList)
        {
            if (id != ContactList.Id)
            {
                return BadRequest();
            }

            cmsEntities.Entry(ContactList).State = EntityState.Modified;

            try
            {
                cmsEntities.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactListExists(id))
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
        [ResponseType(typeof(ContactList))]
        public IHttpActionResult PostContactList(ContactList ContactList)
        {
            cmsEntities.ContactLists.Add(ContactList);
            cmsEntities.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ContactList.Id }, ContactList);
        }

        // DELETE: api/CMS/5
        [ResponseType(typeof(ContactList))]
        public IHttpActionResult DeleteContactList(int id)
        {
            ContactList ContactList = cmsEntities.ContactLists.Find(id);
            if (ContactList == null)
            {
                return NotFound();
            }

            cmsEntities.ContactLists.Remove(ContactList);
            cmsEntities.SaveChanges();

            return Ok(ContactList);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                cmsEntities.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContactListExists(int id)
        {
            return cmsEntities.ContactLists.Count(e => e.Id == id) > 0;
        }
    }
}