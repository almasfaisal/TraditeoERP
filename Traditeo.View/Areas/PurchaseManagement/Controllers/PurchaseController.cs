﻿using System;
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
            var purchaseDocument = new DAL.PurchaseManagement.Purchases().GetPurchaseInformation(0);
            ViewBag.BranchSelectList = new SelectList(new DAL.ApplicationSetup.GeneralSetup.Branches().BranchList.ToList<Models.ApplicationSetup.GeneralSetup.Branches>(), "BranchID", "Branch", purchaseDocument.BranchID);
            return View("Purchase", purchaseDocument);
        }

        public ActionResult Edit(int id)
        {
            var purchaseDocument = new DAL.PurchaseManagement.Purchases().GetPurchaseInformation(id);
            ViewBag.BranchSelectList = new SelectList(new DAL.ApplicationSetup.GeneralSetup.Branches().BranchList.ToList<Models.ApplicationSetup.GeneralSetup.Branches>(), "BranchID", "Branch", purchaseDocument.BranchID);
            ViewBag.VendorSelectList = new SelectList(new DAL.BusinessPartner.Vendors().VendorList.ToList<Models.BusinessPartner.Vendors>(), "VendorID", "VendorName", purchaseDocument.VendorID);
            ViewBag.PaymentTermSelectList = new SelectList(new DAL.ApplicationSetup.GeneralSetup.PaymentTerms().PaymentTermList.ToList<Models.ApplicationSetup.GeneralSetup.PaymentTerms>(), "PaymentTermID", "PaymentTerm", purchaseDocument.PaymentTermID);
            ViewBag.PurchaseAuthoritySelectList = new SelectList(new Traditeo.DAL.Security.Users ().UserList.ToList<Models.Security.Users>(), "UserID", "DisplayName", purchaseDocument.PurchaseAuthorityID);

            return View("Purchase", purchaseDocument);
        }
    }
}