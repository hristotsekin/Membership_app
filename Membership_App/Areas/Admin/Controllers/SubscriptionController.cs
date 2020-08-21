using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Membership_App.Entities;
using Membership_App.Models;

namespace Membership_App.Areas.Admin.Controllers
{
    public class SubscriptionController : Controller
    {
        private UnitOfWork _unitOfWork;

        public SubscriptionController()
        {
            _unitOfWork = new UnitOfWork();
        }

        public SubscriptionController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Admin/Subscription
        public ActionResult Index()
        {
            return View(_unitOfWork.Repository<Subscription>().GetAll());
        }

        public ActionResult Details(int id)
        {
            return View(_unitOfWork.Repository<Subscription>().Get(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Subscription subscription)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Repository<Subscription>().Add(subscription);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(subscription);
        }

        public ActionResult Edit(int id)
        {


            Subscription subscription = _unitOfWork.Repository<Subscription>().Get(id);

            if (subscription == null)
            {
                return HttpNotFound();
            }

            return View(subscription);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Subscription subscription)
        {

            if (ModelState.IsValid)
            {
                Subscription _subscription = _unitOfWork.Repository<Subscription>().Get(subscription.Id);
                _subscription.Title = subscription.Title;
                _subscription.Description = subscription.Description;
                _subscription.RegistrationCode = subscription.RegistrationCode;
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }


            return View(subscription);
        }

        public ActionResult Delete(int id)
        {

            Subscription subscription = _unitOfWork.Repository<Subscription>().Get(id);

            if (subscription == null)
            {
                return HttpNotFound();
            }

            return View(subscription);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(int id)
        {

            Subscription subscription = _unitOfWork.Repository<Subscription>().Get(id);
            if (subscription != null)
            {
                _unitOfWork.Repository<Subscription>().Remove(subscription);
                _unitOfWork.Save();

            }

            return RedirectToAction("Index");
        }
    }
}