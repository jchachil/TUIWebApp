using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TUIFront.Helper
{
    
    /// <summary>
    /// define all web api routes
    /// </summary>
    public class WebApiRoutes
    {
        public const string GetFlightListActionName = "api/Flight/GetFlightList";
        public const string AddFlightListActionName = "api/Flight/AddFlight";
        public const string UpdateFlightListActionName = "api/Flight/UpdateFlight";

        public const string GetAllCountriesListActionName = "api/Country/GetAllCountriesList";
        public const string GetAllAirportsListActionName = "api/Airports/GetAllAirportsList";
        public const string GetAirportsByCountryActionName = "api/Airport/GetAirportsByCountry";
        public const string GetFlightByIdActionName = "api/Flight/GetFlightById?Id=";
    }

}