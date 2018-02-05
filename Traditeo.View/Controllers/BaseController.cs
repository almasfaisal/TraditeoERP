using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Traditeo.Models.Utility;

namespace Traditeo.Controllers
{
    public class BaseController : Controller
    {
        protected ProfileData _profileData = null;

        private void SetProfileData(int userID, int businessPeriodID)
        {
            _profileData.UserID = userID;
            _profileData.BusinessPeriodID = businessPeriodID;
        }
    }
}