﻿using Membership_App.Models;
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

        private readonly UnitOfWork _unitOfWork;

        public PartController()
        {
            _unitOfWork = new UnitOfWork();
        }

        public PartController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {

            return View(_unitOfWork.Repository<Part>().GetAll());
        }

        public ActionResult Details(int id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Part part = _unitOfWork.Repository<Part>().Get(id);

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
                _unitOfWork.Repository<Part>().Add(part);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(part);
        }



        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Part part = _unitOfWork.Repository<Part>().Get(id);

            if (part == null)
            {
                return HttpNotFound();
            }

            return View(part);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "Id,Title")] Part part)
        {

            if (ModelState.IsValid)
            {
                Part p =_unitOfWork.Repository<Part>().Get(part.Id);
                p.Title = part.Title;
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }


            return View(part);
        }


        public ActionResult Delete(int id)
        {
            
            Part part = _unitOfWork.Repository<Part>().Get(id);

            if (part == null)
            {
                return HttpNotFound();
            }

            return View(part);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(int id)
        {

            Part part = _unitOfWork.Repository<Part>().Get(id);
            if (part != null)
            {
                _unitOfWork.Repository<Part>().Remove(part);
                _unitOfWork.Save();

            }

            return RedirectToAction("Index");
        }

        
    }
}