using Membership_App.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Membership_App.Areas.Admin.Controllers
{
    public class PartController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Part
        public ActionResult Index()
        {


            
            return View();
        }
    }
}