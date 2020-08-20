using Membership_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Membership_App.Entities;
using System.Net;

namespace Membership_App.Areas.Admin.Controllers
{
    public class ItemsController : Controller
    {
        private UnitOfWork _unitOfWork;

        public ItemsController()
        {
            _unitOfWork = new UnitOfWork();
        }
        // GET: Admin/Items
        public ActionResult Index()
        {
            
            
            return View(_unitOfWork.Repository<Item>().GetAll().ToList());
        }

        public ActionResult Details(int id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Item item = _unitOfWork.Repository<Item>().Get(id);
            item.Sections = _unitOfWork.Repository<Section>().GetAll().ToList();
            item.Parts = _unitOfWork.Repository<Part>().GetAll().ToList();
            item.ItemTypes = _unitOfWork.Repository<ItemType>().GetAll().ToList();

            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }

        public ActionResult Create()
        {
            var model = new Item
            {
                ItemTypes = _unitOfWork.Repository<ItemType>().GetAll().ToList(),
                Parts = _unitOfWork.Repository<Part>().GetAll().ToList(),
                Sections = _unitOfWork.Repository<Section>().GetAll().ToList()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Item item)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Repository<Item>().Add(item);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(item);
        }

        public ActionResult Edit(int id)
        {


            Item item = _unitOfWork.Repository<Item>().Get(id);
            item.Sections = _unitOfWork.Repository<Section>().GetAll().ToList();
            item.Parts = _unitOfWork.Repository<Part>().GetAll().ToList();
            item.ItemTypes = _unitOfWork.Repository<ItemType>().GetAll().ToList();

            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Item item)
        {

            if (ModelState.IsValid)
            {
                Item _item = _unitOfWork.Repository<Item>().Get(item.Id);
                _item.Title = item.Title;
                _item.Description = item.Description;
                _item.Url = item.Url;
                _item.ImageUrl = item.ImageUrl;
                _item.HTML = item.HTML;
                _item.WaitDays = item.WaitDays;
                _item.IsFree = item.IsFree;
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }


            return View(item);
        }

        public ActionResult Delete(int id)
        {

            Item item = _unitOfWork.Repository<Item>().Get(id);
            item.Sections = _unitOfWork.Repository<Section>().Find(m => m.Id == item.SectionId).ToList();
            item.Parts = _unitOfWork.Repository<Part>().Find(m => m.Id == item.PartId).ToList();
            item.ItemTypes = _unitOfWork.Repository<ItemType>().Find(m => m.Id == item.ItemTypeId).ToList();

            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(int id)
        {

            Item item = _unitOfWork.Repository<Item>().Get(id);
            if (item != null)
            {
                _unitOfWork.Repository<Item>().Remove(item);
                _unitOfWork.Save();

            }

            return RedirectToAction("Index");
        }
    }
}