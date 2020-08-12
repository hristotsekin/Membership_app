using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Membership_App.Entities;
using Membership_App.Models;

namespace Membership_App.Areas.Admin.Controllers
{
    public class SectionController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Section
        public async  Task<ActionResult> Index()
        {

            return View(await db.Sections.ToListAsync());
        }

        public async Task<ActionResult> Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Section section = await db.Sections.FindAsync(id);

            if (section == null)
            {
                return HttpNotFound();
            }

            return View(section);
        }

        public async Task<ActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(
            [Bind(Include = "Id,Title")] Section section)
        {
            if (ModelState.IsValid)
            {
                db.Sections.Add(section);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(section);
        }



        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Section section = await db.Sections.FindAsync(id);

            if (section == null)
            {
                return HttpNotFound();
            }

            return View(section);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(
            [Bind(Include = "Id,Title")] Section section)
        {

            if (ModelState.IsValid)
            {
                db.Entry(section).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }


            return View(section);
        }


        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Section section = await db.Sections.FindAsync(id);

            if (section == null)
            {
                return HttpNotFound();
            }

            return View(section);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ConfirmDelete(int id)
        {

            Section section = await db.Sections.FindAsync(id);
            if (section != null)
            {
                db.Sections.Remove(section);
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