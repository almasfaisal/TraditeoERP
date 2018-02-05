using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Reflection;
using Newtonsoft.Json.Linq;

namespace Traditeo.Areas.PurchaseManagement.Controllers
{
    [Authorize]
    public class PurchaseController : Controller
    {
        public ActionResult Index()
        {
            return View(new DAL.PurchaseManagement.Purchases().ShowPurchases());
        }

        [ValidateInput(false)]
        public ActionResult ShowView()
        {
            Dictionary<string, string> columnHeader =new Dictionary<string, string>();
            columnHeader.Add("PurchaseNumber", "Purchase Number");
            columnHeader.Add("PurchaseDate", "Purchase Date");
            columnHeader.Add("DueDate", "Due Date");
            columnHeader.Add("BranchCode", "Branch Code");
            columnHeader.Add("Branch", "Branch");
            columnHeader.Add("VendorCode", "Vendor Code");
            columnHeader.Add("Vendor", "Vendor");
            ViewBag.ColumnHeader = columnHeader;

            return PartialView("ViewControl", new DAL.PurchaseManagement.Purchases().ShowPurchases());
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
            ViewBag.PurchaseAuthoritySelectList = new SelectList(new Traditeo.DAL.Security.Users().UserList.ToList<Models.Security.Users>(), "UserID", "DisplayName", purchaseDocument.PurchaseAuthorityID);
            ViewBag.CurrencySelectList = new SelectList(new DAL.ApplicationSetup.GeneralSetup.Currencies().CurrencyList.ToList<Models.ApplicationSetup.GeneralSetup.Currencies>(), "CurrencyID", "Currency", purchaseDocument.CurrencyID);

            return View("Purchase", purchaseDocument);
        }

        [HttpPost]
        public ActionResult Save(Int64 purchaseID,string purchaseJSON)
        {
            new DAL.PurchaseManagement.Purchases().SavePurchase(purchaseID, purchaseJSON);
            return View("Index",new DAL.PurchaseManagement.Purchases().ShowPurchases());
        }

        ////[SubmitButton(Name ="Save")]
        ////public ActionResult Save()
        ////{
        ////    return PartialView("ViewControl", new DAL.PurchaseManagement.Purchases().ShowPurchases());
        ////}

        //[SubmitButton(Name = "Submit")]
        //public ActionResult Submit()
        //{
        //    return Content("Submit Called");
        //}
    }
    
    public class SubmitButton:ActionNameSelectorAttribute
    {
        public string Name { get; set; }

        public override bool IsValidName(ControllerContext controllerContext, string actionName, MethodInfo methodInfo)
        {
            var value = controllerContext.Controller.ValueProvider.GetValue(Name);

            if (value == null)
                return false;
            else 
                return true;    
        }
    }
}