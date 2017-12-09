using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Traditeo.Areas.PurchaseManagement.Controllers
{
    [Authorize]
    public class PurchaseController : Controller
    {
        public ActionResult Index()
        {
              
            return View(new DAL.PurchaseManagement.Purchases().PurchaseList);
        }
    }
}