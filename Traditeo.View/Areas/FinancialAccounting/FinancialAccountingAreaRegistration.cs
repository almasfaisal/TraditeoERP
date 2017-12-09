using System.Web.Mvc;

namespace Traditeo.Areas.FinancialAccounting
{
    public class FinancialAccountingAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "FinancialAccounting";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "FinancialAccounting_default",
                "FinancialAccounting/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}