﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ERP.Web.Models.Database;

namespace ERP.Web.Api.ApiKho
{
    public class Api_HangSanPhamController : ApiController
    {
        private HOPLONG_DATABASEEntities db = new HOPLONG_DATABASEEntities();

        // GET: api/Api_HangSanPham
        public IQueryable<DM_HANG_SP> GetDM_HANG_SP()
        {
            return db.DM_HANG_SP;
        }

        // GET: api/Api_HangSanPham/5
        [ResponseType(typeof(DM_HANG_SP))]
        public IHttpActionResult GetDM_HANG_SP(string id)
        {
            DM_HANG_SP dM_HANG_SP = db.DM_HANG_SP.Find(id);
            if (dM_HANG_SP == null)
            {
                return NotFound();
            }

            return Ok(dM_HANG_SP);
        }

        // PUT: api/Api_HangSanPham/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDM_HANG_SP(string id, DM_HANG_SP dM_HANG_SP)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dM_HANG_SP.MA_NHOM_HANG)
            {
                return BadRequest();
            }

            db.Entry(dM_HANG_SP).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DM_HANG_SPExists(id))
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

        // POST: api/Api_HangSanPham
        [ResponseType(typeof(DM_HANG_SP))]
        public IHttpActionResult PostDM_HANG_SP(DM_HANG_SP dM_HANG_SP)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DM_HANG_SP.Add(dM_HANG_SP);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DM_HANG_SPExists(dM_HANG_SP.MA_NHOM_HANG))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = dM_HANG_SP.MA_NHOM_HANG }, dM_HANG_SP);
        }

        // DELETE: api/Api_HangSanPham/5
        [ResponseType(typeof(DM_HANG_SP))]
        public IHttpActionResult DeleteDM_HANG_SP(string id)
        {
            DM_HANG_SP dM_HANG_SP = db.DM_HANG_SP.Find(id);
            if (dM_HANG_SP == null)
            {
                return NotFound();
            }

            db.DM_HANG_SP.Remove(dM_HANG_SP);
            db.SaveChanges();

            return Ok(dM_HANG_SP);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DM_HANG_SPExists(string id)
        {
            return db.DM_HANG_SP.Count(e => e.MA_NHOM_HANG == id) > 0;
        }
    }
}