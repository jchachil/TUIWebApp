using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using TUIFront.Areas.TUIFlight.Models;
using TUIFront.Controllers;
using TUIFront.Helper;
using TUIFront.Models;
using TUIFrontEnd.Util;

namespace TUIFront.Areas.TUIFlight.Controllers
{
    /// <summary>
    /// Flight Controller class
    /// </summary>
    public class FlightController : BaseController
    {

        /// <summary>
        /// display all flight from database
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            List<FlightModel> flightList = GetFlightList();
            return View(flightList);
        }

        /// <summary>
        /// Add flight Get Action
        /// </summary>
        /// <returns></returns>
        public ActionResult AddFlight()
        {
            //get countries from the cache
            List<CountryModel> countries = GetOrSetCacheData(CacheKey.Countries, () =>
             GetCountriesList());

            FlightModel flighModel = new FlightModel();
            flighModel.DepartCountries = countries.Select(x => new SelectListItem()
            {
                Text = x.CountryName,
                Value = x.Id.ToString()
            }).ToList();

            flighModel.DestinationCountries = countries.Select(x => new SelectListItem()
            {
                Text = x.CountryName,
                Value = x.Id.ToString()
            }).ToList();

            //Get airports list from the cache
            List<AirportModel> airportsList = GetOrSetCacheData(CacheKey.Airports, () =>
             GetAirportsList());

            flighModel.DepartAirports = airportsList.Select(x => new SelectListItem()
            {
                Text = string.Concat(x.AirportCode, " ", x.AirportName),
                Value = x.Id.ToString()
            }).ToList();

            flighModel.DestinationAirports = airportsList.Select(x => new SelectListItem()
            {
                Text = string.Concat(x.AirportCode, " ", x.AirportName),
                Value = x.Id.ToString()
            }).ToList();
            
            return View(flighModel);
        }

        /// <summary>
        /// Add Flight Post action call the web api to save data
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddFlight(FlightModel model)
        {            

            if (ModelState.IsValid)
            {
                string postBody = JsonConvert.SerializeObject(model);

                var response = WebApiCaller.CallSyncStatement(Config.RessourceEndPoint, WebApiRoutes.AddFlightListActionName , postBody);                
            }


            return RedirectToAction("Index");
        }

        /// <summary>
        /// Update flight Get action
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult UpdateFlight(int id)
        {
            FlightModel flighModel = GetFlightById(id);

            
            List<CountryModel> countries = GetOrSetCacheData(CacheKey.Countries, () =>
                GetCountriesList());


            flighModel.DepartCountries = countries.Select(x => new SelectListItem()
            {
                Text = x.CountryName,
                Value = x.Id.ToString()
            }).ToList();

            flighModel.DestinationCountries = countries.Select(x => new SelectListItem()
            {
                Text = x.CountryName,
                Value = x.Id.ToString()
            }).ToList();

            
            List<AirportModel> airportsList = GetOrSetCacheData(CacheKey.Airports, () =>
               GetAirportsList());


            flighModel.SelectedDepCountryId = airportsList.First(elt => elt.Id == flighModel.DepartureAirport_Id).Country_Id.ToString();
            flighModel.SelectedDestCountryId = airportsList.First(elt => elt.Id == flighModel.DestinationAirport_Id).Country_Id.ToString();


            flighModel.DepartAirports = airportsList.Where(elt => elt.Country_Id.ToString() == flighModel.SelectedDepCountryId).Select(x => new SelectListItem()
            {
                Text = string.Concat(x.AirportCode, " ", x.AirportName),
                Value = x.Id.ToString()
            }).ToList();

            flighModel.DestinationAirports = airportsList.Where(elt => elt.Country_Id.ToString() == flighModel.SelectedDestCountryId).Select(x => new SelectListItem()
            {
                Text = string.Concat(x.AirportCode, " ", x.AirportName),
                Value = x.Id.ToString()
            }).ToList();


            return View(flighModel);
        }

        /// <summary>
        /// Update flight Post action : send data to web api to save it
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UpdateFlight(FlightModel model)
        {
            if (ModelState.IsValid)
            {
                string postBody = JsonConvert.SerializeObject(model);                
                var response = WebApiCaller.CallSyncStatement(Config.RessourceEndPoint, WebApiRoutes.UpdateFlightListActionName , postBody);
               
            }

            return RedirectToAction("index", "Flight");
        }

        /// <summary>
        /// Get the detail of flight
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DetailFlight(int id)
        {
            FlightModel flighModel = GetFlightById(id);
            
            List<CountryModel> countries = GetOrSetCacheData(CacheKey.Countries, () =>
                GetCountriesList());

            flighModel.DepartCountries = countries.Select(x => new SelectListItem()
            {
                Text = x.CountryName,
                Value = x.Id.ToString()
            }).ToList();

            flighModel.DestinationCountries = countries.Select(x => new SelectListItem()
            {
                Text = x.CountryName,
                Value = x.Id.ToString()
            }).ToList();

            
            List<AirportModel> airportsList = GetOrSetCacheData(CacheKey.Airports, () =>
               GetAirportsList());


            flighModel.DepartAirports = airportsList.Select(x => new SelectListItem()
            {
                Text = string.Concat(x.AirportCode, " ", x.AirportName),
                Value = x.Id.ToString()
            }).ToList();

            flighModel.DestinationAirports = airportsList.Select(x => new SelectListItem()
            {
                Text = string.Concat(x.AirportCode, " ", x.AirportName),
                Value = x.Id.ToString()
            }).ToList();

            flighModel.SelectedDepCountryId = airportsList.First(elt => elt.Id == flighModel.DepartureAirport_Id).Country_Id.ToString();
            flighModel.SelectedDestCountryId = airportsList.First(elt => elt.Id == flighModel.DestinationAirport_Id).Country_Id.ToString();

            flighModel.DepartureCountryName = countries.First(elt => elt.Id.ToString() == flighModel.SelectedDepCountryId).CountryName;
            flighModel.DestinationCountryName = countries.First(elt => elt.Id.ToString() == flighModel.SelectedDestCountryId).CountryName;

            return View(flighModel);

        }

        /// <summary>
        /// Get airports of some country
        /// </summary>
        /// <param name="CountryId"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetAirportsByCountryId(int CountryId = 0)
        {
            List<AirportModel> airportsList = GetOrSetCacheData(CacheKey.Airports, () =>
              GetAirportsList());
            var result = airportsList.Where(elt => elt.Country_Id == CountryId).ToList();
            return Json(result);

        }

        /// <summary>
        /// Get countries from webapi
        /// </summary>
        /// <returns></returns>
        private List<CountryModel> GetCountriesList()
        {
            
            var response = WebApiCaller.RunGetSyncStatement(Config.RessourceEndPoint, WebApiRoutes.GetAllCountriesListActionName );
            List<CountryModel> countriesList = new List<CountryModel>();
            if (response.IsSuccessStatusCode)
            {
                string responseString = response.Content.ReadAsStringAsync().Result;
                countriesList = JsonConvert.DeserializeObject<List<CountryModel>>(responseString);
            }
            return countriesList;

        }

        /// <summary>
        /// Get airport List from webapi
        /// </summary>
        /// <returns></returns>
        private List<AirportModel> GetAirportsList()
        {   
            List<AirportModel> airportsList = new List<AirportModel>();
            
            var response = WebApiCaller.RunGetSyncStatement(Config.RessourceEndPoint, WebApiRoutes.GetAllAirportsListActionName);

            if (response.IsSuccessStatusCode)
            {
                string responseString = response.Content.ReadAsStringAsync().Result;
                airportsList = JsonConvert.DeserializeObject<List<AirportModel>>(responseString);
            }
            return airportsList;

        }

        /// <summary>
        /// Get detail flight by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private FlightModel GetFlightById(int id)
        {
           var response = WebApiCaller.RunGetSyncStatement(Config.RessourceEndPoint, WebApiRoutes.GetFlightByIdActionName  +id.ToString());

            FlightModel flight = new FlightModel();
            if (response.IsSuccessStatusCode)
            {
                string responseString = response.Content.ReadAsStringAsync().Result;
                flight = JsonConvert.DeserializeObject<FlightModel>(responseString);
            }
            return flight;

        }

        /// <summary>
        /// Get flight list from web api
        /// </summary>
        /// <returns></returns>
        private List<FlightModel> GetFlightList()
        {
             var response = WebApiCaller.RunGetSyncStatement(Config.RessourceEndPoint, WebApiRoutes.GetFlightListActionName);
            

            List<FlightModel> flightList = new List<FlightModel>();
            if (response.IsSuccessStatusCode)
            {
                string responseString = response.Content.ReadAsStringAsync().Result;
                flightList = JsonConvert.DeserializeObject<List<FlightModel>>(responseString);
            }
            return flightList;

        }

    }
}