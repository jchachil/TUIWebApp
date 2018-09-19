using System.Web.Mvc;

namespace TUIFront.Areas.TUIFlight
{
    public class TUIFlightAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "TUIFlight";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "TUIFlight_default",
                "TUIFlight/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}