using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        private string _queryString;
        private Int64 _itemID;
        private string _itemCode;
        private string _itemName;
        private string _itemAlias;

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
        public ActionResult ItemLookup(int rowID, int warehouseID)
        {
            ViewBag.RowID = rowID;
            ViewBag.WarehouseID = warehouseID;
            return PartialView("../Lookups/Items");
            //return PartialView("../Lookups/Items", new { rowID = rowID, warehouseID = warehouseID });
        }

        [HttpPost]
        public ActionResult CreateBatchLookup(int rowID, int itemID)
        {
            ViewBag.RowID = rowID;
            ViewBag.ItemID = itemID;
            return PartialView("../Lookups/CreateBatch");
        }
        
        public JsonResult GetItems()
        {
            List<Models.ItemManagement.Items> itemList=null;

            if (Request.QueryString.Count ==0)
            {
                itemList = new DAL.ItemManagement.Items().ItemList.Take(20).ToList();
            }
            else
            {
                var queryResult = JObject.Parse(Request.QueryString[0]);

                if (queryResult.Count == 1)
                {
                    if (queryResult["ItemID"] !=null)
                        _itemID = Convert.ToInt64(queryResult["ItemID"].ToString());

                    if (queryResult["ItemCode"] != null)
                        _itemCode = queryResult["ItemCode"].ToString();

                    itemList = new DAL.ItemManagement.Items().ItemList.Where(m => m.ItemID == _itemID || m.ItemCode == _itemCode).ToList<Models.ItemManagement.Items>();
                }
                else if (queryResult.Count == 2)
                {
                    _itemID = Convert.ToInt64(queryResult["ItemID"].ToString());
                    _itemCode = queryResult["ItemCode"].ToString();
                    itemList = new DAL.ItemManagement.Items().ItemList.Where(m => m.ItemID == _itemID || m.ItemCode == _itemCode).ToList<Models.ItemManagement.Items>();
                }
                else if (queryResult.Count > 2)
                {
                    _itemCode = queryResult["ItemCode"].ToString();
                    _itemName = queryResult["ItemName"].ToString();
                    _itemAlias = queryResult["ItemAlias"].ToString();
                    itemList = new DAL.ItemManagement.Items().ItemList.Where
                        (
                            m => ((_itemCode.Length==0) || m.ItemCode.Contains(_itemCode)) &&
                            ((_itemName.Length == 0) || m.ItemName.Contains(_itemName)) &&
                            ((_itemAlias.Length == 0) || m.ItemAlias.Contains(_itemAlias)) 
                        ).ToList<Models.ItemManagement.Items>().Take(20).ToList();
                }

            }
            itemList.ForEach(u => u.id = u.ItemID);
            return Json(itemList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetBatches()
        {
            try
            {
                List<Models.ItemManagement.ItemBatches> itemBatchList = null;

                if (Request.QueryString.Count == 0)
                {
                    itemBatchList = new DAL.ItemManagement.ItemBatches().ItemBatchList.Take(20).ToList();
                }
                else
                {
                    var queryResult = JObject.Parse(Request.QueryString[0]);

                    if (queryResult.Count == 1)
                    {
                        if (queryResult["ItemID"] != null)
                            _itemID = Convert.ToInt64(queryResult["ItemID"].ToString());

                        itemBatchList = new DAL.ItemManagement.ItemBatches().ItemBatchList.Where(m => m.ItemID == _itemID).ToList<Models.ItemManagement.ItemBatches>();
                    }
                }
                itemBatchList.ForEach(u => u.id = u.ItemBatchID);
                return Json(itemBatchList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception Ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }


    }
}