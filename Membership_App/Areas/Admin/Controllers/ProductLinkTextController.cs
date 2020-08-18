using Membership_App.Entities;
using Membership_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Membership_App.Areas.Admin.Controllers
{
    public class ProductLinkTextController : Controller
    {
        private readonly UnitOfWork _unitOfWork;

        public ProductLinkTextController()
        {
            _unitOfWork = new UnitOfWork();
        }

        public ProductLinkTextController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {

            return View(_unitOfWork.Repository<ProductLinkText>().GetAll());
        }

        public ActionResult Details(int id)
        {


            ProductLinkText productLinkText = _unitOfWork.Repository<ProductLinkText>().Get(id);

            if (productLinkText == null)
            {
                return HttpNotFound();
            }

            return View(productLinkText);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "Id,Title")] ProductLinkText productLinkText)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Repository<ProductLinkText>().Add(productLinkText);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(productLinkText);
        }



        public ActionResult Edit(int id)
        {


            ProductLinkText productLinkText = _unitOfWork.Repository<ProductLinkText>().Get(id);

            if (productLinkText == null)
            {
                return HttpNotFound();
            }

            return View(productLinkText);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "Id,Title")] ProductLinkText productLinkText)
        {

            if (ModelState.IsValid)
            {
                ProductLinkText p = _unitOfWork.Repository<ProductLinkText>().Get(productLinkText.Id);
                p.Title = productLinkText.Title;
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }


            return View(productLinkText);
        }


        public ActionResult Delete(int id)
        {

            ProductLinkText productLinkText = _unitOfWork.Repository<ProductLinkText>().Get(id);

            if (productLinkText == null)
            {
                return HttpNotFound();
            }

            return View(productLinkText);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(int id)
        {

            ProductLinkText productLinkText = _unitOfWork.Repository<ProductLinkText>().Get(id);
            if (productLinkText != null)
            {
                _unitOfWork.Repository<ProductLinkText>().Remove(productLinkText);
                _unitOfWork.Save();

            }

            return RedirectToAction("Index");
        }
    }
}