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

namespace ERP.Web.Api.ApiHeThong
{
    public class Api_NghiepVuNhanVienController : ApiController
    {
        private HOPLONG_DATABASEEntities db = new HOPLONG_DATABASEEntities();

        // GET: api/Api_NghiepVuNhanVien
        public IQueryable<CN_NGHIEP_VU_NHAN_VIEN> GetCN_NGHIEP_VU_NHAN_VIEN()
        {
            return db.CN_NGHIEP_VU_NHAN_VIEN;
        }

        // GET: api/Api_NghiepVuNhanVien/5
        [ResponseType(typeof(CN_NGHIEP_VU_NHAN_VIEN))]
        public IHttpActionResult GetCN_NGHIEP_VU_NHAN_VIEN(int id)
        {
            CN_NGHIEP_VU_NHAN_VIEN cN_NGHIEP_VU_NHAN_VIEN = db.CN_NGHIEP_VU_NHAN_VIEN.Find(id);
            if (cN_NGHIEP_VU_NHAN_VIEN == null)
            {
                return NotFound();
            }

            return Ok(cN_NGHIEP_VU_NHAN_VIEN);
        }

        // PUT: api/Api_NghiepVuNhanVien/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCN_NGHIEP_VU_NHAN_VIEN(int id, CN_NGHIEP_VU_NHAN_VIEN cN_NGHIEP_VU_NHAN_VIEN)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cN_NGHIEP_VU_NHAN_VIEN.ID_CHI_TIET_NGHIEP_VU)
            {
                return BadRequest();
            }

            db.Entry(cN_NGHIEP_VU_NHAN_VIEN).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CN_NGHIEP_VU_NHAN_VIENExists(id))
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

        // POST: api/Api_NghiepVuNhanVien
        [ResponseType(typeof(CN_NGHIEP_VU_NHAN_VIEN))]
        public IHttpActionResult PostCN_NGHIEP_VU_NHAN_VIEN(CN_NGHIEP_VU_NHAN_VIEN cN_NGHIEP_VU_NHAN_VIEN)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CN_NGHIEP_VU_NHAN_VIEN.Add(cN_NGHIEP_VU_NHAN_VIEN);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CN_NGHIEP_VU_NHAN_VIENExists(cN_NGHIEP_VU_NHAN_VIEN.ID_CHI_TIET_NGHIEP_VU))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cN_NGHIEP_VU_NHAN_VIEN.ID_CHI_TIET_NGHIEP_VU }, cN_NGHIEP_VU_NHAN_VIEN);
        }

        // DELETE: api/Api_NghiepVuNhanVien/5
        [ResponseType(typeof(CN_NGHIEP_VU_NHAN_VIEN))]
        public IHttpActionResult DeleteCN_NGHIEP_VU_NHAN_VIEN(int id)
        {
            CN_NGHIEP_VU_NHAN_VIEN cN_NGHIEP_VU_NHAN_VIEN = db.CN_NGHIEP_VU_NHAN_VIEN.Find(id);
            if (cN_NGHIEP_VU_NHAN_VIEN == null)
            {
                return NotFound();
            }

            db.CN_NGHIEP_VU_NHAN_VIEN.Remove(cN_NGHIEP_VU_NHAN_VIEN);
            db.SaveChanges();

            return Ok(cN_NGHIEP_VU_NHAN_VIEN);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CN_NGHIEP_VU_NHAN_VIENExists(int id)
        {
            return db.CN_NGHIEP_VU_NHAN_VIEN.Count(e => e.ID_CHI_TIET_NGHIEP_VU == id) > 0;
        }
    }
}