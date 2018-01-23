using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Traditeo.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private Models.Utility.Menus _menus;
        public ActionResult Index()
        {
            return View();
        }

        public string GetMenuHTML()
        {
            _menus = new Models.Utility.Menus();
            return _menus.BindTree(new DAL.Utility.Menus().MenuList.ToList<Models.Utility.Menus>().Where(m => m.IsActive == true).ToList<Models.Utility.Menus>());
        }
        public JsonResult GetWarehouse()
        {
            return Json(new DAL.ApplicationSetup.Inventory.Warehouses().WarehouseList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ItemLookup(int rowID)
        {
            return PartialView("../Lookups/Items");
        }
        public JsonResult GetItems()
        {
            var itemList = new DAL.ItemManagement.Items().ItemList.Take(20).ToList();
            itemList.ForEach(u => u.id = u.ItemID);
            return Json(itemList, JsonRequestBehavior.AllowGet);

            //return Json(new DAL.ItemManagement.Items().ItemList.Take(20).ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}