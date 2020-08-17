using Membership_App.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Membership_App.Entities;

namespace Membership_App.Areas.Admin.Controllers
{
    public class PartController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Section

        private readonly IUnitOfWork _unitOfWork;

        public PartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ActionResult> Index()
        {

            return View(await db.Parts.ToListAsync());
        }

        public async Task<ActionResult> Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Part part = await db.Parts.FindAsync(id);

            if (part == null)
            {
                return HttpNotFound();
            }

            return View(part);
        }

        public async Task<ActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(
            [Bind(Include = "Id,Title")] Part part)
        {
            if (ModelState.IsValid)
            {
                db.Parts.Add(part);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(part);
        }



        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Part part = await db.Parts.FindAsync(id);

            if (part == null)
            {
                return HttpNotFound();
            }

            return View(part);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(
            [Bind(Include = "Id,Title")] Part part)
        {

            if (ModelState.IsValid)
            {
                db.Entry(part).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }


            return View(part);
        }


        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Part part = await db.Parts.FindAsync(id);

            if (part == null)
            {
                return HttpNotFound();
            }

            return View(part);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ConfirmDelete(int id)
        {

            Part part = await db.Parts.FindAsync(id);
            if (part != null)
            {
                db.Parts.Remove(part);
                await db.SaveChangesAsync();

            }

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}