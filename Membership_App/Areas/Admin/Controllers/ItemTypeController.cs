using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Membership_App.Entities;
using Membership_App.Models;

namespace Membership_App.Areas.Admin.Controllers
{
    public class ItemTypeController : Controller
    {
        // GET: Admin/ItemType
        private readonly UnitOfWork _unitOfWork;

        public ItemTypeController()
        {
            _unitOfWork = new UnitOfWork();
        }

        public ItemTypeController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {

            return View(_unitOfWork.Repository<ItemType>().GetAll());
        }

        public ActionResult Details(int id)
        {


            ItemType itemType = _unitOfWork.Repository<ItemType>().Get(id);

            if (itemType == null)
            {
                return HttpNotFound();
            }

            return View(itemType);
        }

        public async Task<ActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(
            [Bind(Include = "Id,Title")] ItemType itemType)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Repository<ItemType>().Add(itemType);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(itemType);
        }



        public ActionResult Edit(int id)
        {
            

            ItemType itemType = _unitOfWork.Repository<ItemType>().Get(id);

            if (itemType == null)
            {
                return HttpNotFound();
            }

            return View(itemType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "Id,Title")] ItemType itemType)
        {

            if (ModelState.IsValid)
            {
                ItemType p = _unitOfWork.Repository<ItemType>().Get(itemType.Id);
                p.Title = itemType.Title;
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }


            return View(itemType);
        }


        public ActionResult Delete(int id)
        {

            ItemType itemType = _unitOfWork.Repository<ItemType>().Get(id);

            if (itemType == null)
            {
                return HttpNotFound();
            }

            return View(itemType);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(int id)
        {

            ItemType itemType = _unitOfWork.Repository<ItemType>().Get(id);
            if (itemType != null)
            {
                _unitOfWork.Repository<ItemType>().Remove(itemType);
                _unitOfWork.Save();

            }

            return RedirectToAction("Index");
        }
    }
}