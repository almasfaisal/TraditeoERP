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
            return View(new DAL.PurchaseManagement.Purchases().ShowPurchases() );
        }

        public ActionResult Create()
        {
            return View("Purchase");
        }

        public ActionResult Edit(int id)
        {
            ViewBag.BranchSelectList = new SelectList(new DAL.ApplicationSetup.GeneralSetup.Branches().BranchList.ToList<Models.ApplicationSetup.GeneralSetup.Branches>(), "BranchID", "Branch");

            return View("Purchase");
        }
    }
}