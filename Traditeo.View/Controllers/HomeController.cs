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
    }
}