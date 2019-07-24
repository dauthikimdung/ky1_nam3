using System.Web.Mvc;

namespace B.Areas.admins
{
    public class adminsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "admins";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "admins_default",
                "admins/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new[] { "B.Areas.admins.Controllers" }
            );
        }
    }
}