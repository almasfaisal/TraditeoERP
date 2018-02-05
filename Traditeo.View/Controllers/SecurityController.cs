using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Traditeo.Controllers
{
    public class SecurityController : BaseController
    {
        private Models.Security.Users _users;
        // GET: Security
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult CheckUser()
        {
            _users = new Models.Security.Users();
            _users = new DAL.Security.Users().GetUsers(Request.Form["UserIDTxt"]);
            _users=_users.GetUsers(_users, Request.Form["PasswordTxt"]);

            if (_users !=null && _users.IsValidated)
            {
                FormsAuthentication.RedirectFromLoginPage(Request.Form["UserIDTxt"], true);
                //_profileData.UserID = _users.UserID;
                //_profileData.BusinessPeriodID = 1;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Login");
            }
        }
    }
}