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
        private readonly UnitOfWork _unitOfWork;

        public SectionController()
        {
            _unitOfWork = new UnitOfWork();
        }
        
        public SectionController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        // GET: Admin/Section
        public ActionResult Index()
        {

            return View(_unitOfWork.Repository<Section>().GetAll());
        }

        public  ActionResult Details(int id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Section section =  _unitOfWork.Repository<Section>().Get(id);

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
        public ActionResult Create(
            [Bind(Include = "Id,Title")] Section section)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Repository<Section>().Add(section);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(section);
        }



        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Section section = _unitOfWork.Repository<Section>().Get(id);

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
                Section s = _unitOfWork.Repository<Section>().Get(section.Id);
                s.Title = section.Title;
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }


            return View(section);
        }


        public ActionResult Delete(int id)
        {
            

            Section section = _unitOfWork.Repository<Section>().Get(id);

            if (section == null)
            {
                return HttpNotFound();
            }

            return View(section);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            Section section = _unitOfWork.Repository<Section>().Get(id);    
            _unitOfWork.Repository<Section>().Remove(section);
            _unitOfWork.Save();

            return RedirectToAction("Index");
        }

       
    }
}