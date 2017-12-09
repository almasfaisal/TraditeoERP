using System.Web.Mvc;

namespace Traditeo.Areas.PurchaseManagement
{
    public class PurchaseManagementAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "PurchaseManagement";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "PurchaseManagement_default",
                "PurchaseManagement/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}