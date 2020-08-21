using Membership_App.Entities;
using Membership_App.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Membership_App.Areas.Admin.Extensions;
using Membership_App.Areas.Admin.Models;

namespace Membership_App.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private UnitOfWork _unitOfWork;

        public ProductController()
        {
            _unitOfWork = new UnitOfWork();
        }

        public ProductController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            IEnumerable<Product> products = _unitOfWork.Repository<Product>().GetAll();
            return View(products.Convert(_unitOfWork));
        }
        public ActionResult Details(int id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ProductModel product = _unitOfWork.Repository<Product>().Get(id).Convert(_unitOfWork);
           
            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

        public ActionResult Create()
        {
            ProductModel product = new ProductModel
            {
                ProductTypes = _unitOfWork.Repository<ProductType>().GetAll().ToList(),
                ProductLinkTexts = _unitOfWork.Repository<ProductLinkText>().GetAll().ToList()
            };
            
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Title,Description,ImageUrl,ProductLinkTextId,ProductTypeId")]Product product)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Repository<Product>().Add(product);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        public ActionResult Edit(int id)
        {


            ProductModel product = _unitOfWork.Repository<Product>().Get(id).Convert(_unitOfWork);
            
            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include= "Id,Title,Description,ImageUrl,ProductLinkTextId,ProductTypeId")]Product product)
        {

            if (ModelState.IsValid)
            {
                Product _product = _unitOfWork.Repository<Product>().Get(product.Id);
                _product.Title = product.Title;
                _product.Description = product.Description;
                _product.ImageUrl = product.ImageUrl;
                _product.ProductLinkTextId = product.ProductLinkTextId;
                _product.ProductTypeId = product.ProductTypeId;
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }


            return View(product);
        }

        public ActionResult Delete(int id)
        {

            ProductModel product = _unitOfWork.Repository<Product>().Get(id).Convert(_unitOfWork);
            
            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(int id)
        {

            Product product = _unitOfWork.Repository<Product>().Get(id);
            if (product != null)
            {
                _unitOfWork.Repository<Product>().Remove(product);
                _unitOfWork.Save();

            }

            return RedirectToAction("Index");
        }

    }
}