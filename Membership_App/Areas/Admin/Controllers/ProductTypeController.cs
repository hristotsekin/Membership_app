using Membership_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Membership_App.Entities;
using System.Threading.Tasks;

namespace Membership_App.Areas.Admin.Controllers
{
    public class ProductTypeController : Controller
    {
        private readonly UnitOfWork _unitOfWork;

        public ProductTypeController()
        {
            _unitOfWork = new UnitOfWork();
        }

        public ProductTypeController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {

            return View(_unitOfWork.Repository<ProductType>().GetAll());
        }

        public ActionResult Details(int id)
        {


            ProductType productType = _unitOfWork.Repository<ProductType>().Get(id);

            if (productType == null)
            {
                return HttpNotFound();
            }

            return View(productType);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "Id,Title")] ProductType productType)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Repository<ProductType>().Add(productType);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(productType);
        }



        public ActionResult Edit(int id)
        {


            ProductType productType = _unitOfWork.Repository<ProductType>().Get(id);

            if (productType == null)
            {
                return HttpNotFound();
            }

            return View(productType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "Id,Title")] ProductType productType)
        {

            if (ModelState.IsValid)
            {
                ProductType p = _unitOfWork.Repository<ProductType>().Get(productType.Id);
                p.Title = productType.Title;
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }


            return View(productType);
        }


        public ActionResult Delete(int id)
        {

            ProductType productType = _unitOfWork.Repository<ProductType>().Get(id);

            if (productType == null)
            {
                return HttpNotFound();
            }

            return View(productType);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(int id)
        {

            ProductType productType = _unitOfWork.Repository<ProductType>().Get(id);
            if (productType != null)
            {
                _unitOfWork.Repository<ProductType>().Remove(productType);
                _unitOfWork.Save();

            }

            return RedirectToAction("Index");
        }
    }
}