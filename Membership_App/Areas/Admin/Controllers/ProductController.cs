using Membership_App.Entities;
using Membership_App.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Membership_App.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        

        public ActionResult Index()
        {

            return View();
        }

        
    }
}