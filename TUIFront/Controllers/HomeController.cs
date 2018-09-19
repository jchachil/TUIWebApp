using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TUIFront.Models;
using TUIFrontEnd.Util;
using System.Device;
using System.Device.Location;

namespace TUIFront.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("index", "Flight", new { area = "TUIFlight" });            
        }

      
    }
}