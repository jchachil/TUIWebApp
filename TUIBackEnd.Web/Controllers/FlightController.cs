using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TUIBackEnd.BLL;
using TUIBackEnd.Models;
using TUIBackEnd.DAL;
using TUIBackEnd.Web.Helper;
using System.Device.Location;

namespace TUIBackEnd.Web.Controllers
{
    /// <summary>
    /// Flight Controller Class
    /// </summary>
    public class FlightController : BaseController
    {

        /// <summary>
        /// Get all flight from Database
        /// </summary>
        /// <returns></returns>
        [Route(WebApiRoutes.GetFlightListActionName)]
        public IEnumerable<FlightModel> GetFlightList()
        {
            List<Flight> flightList = FlightBLL.Instance.GetFlightsList();

            List<FlightModel> model = new List<FlightModel>();

            model = AutoMapper.Mapper.Map<List<FlightModel>>(flightList);
            return model;
        }

        /// <summary>
        /// Add flight Data
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(WebApiRoutes.AddFlightListActionName)]
        public ResponseModel AddFlight([FromBody] Flight param)
        {
            ResponseModel returnValue = new ResponseModel();

            try
            {
                var _flightBLL = FlightBLL.Instance;
                var airportList = AirportBLL.Instance.GetAirportsList().ToList();
                Airport departureAirport = airportList.First(elt => elt.Id == param.DepartureAirport_Id);
                Airport destinationAirport = airportList.First(elt => elt.Id == param.DestinationAirport_Id);


                // calculate de distance betewen 2 airports using their gps positions
                var departCoord = new GeoCoordinate(departureAirport.Latitude, departureAirport.Longitude);
                var destCoord = new GeoCoordinate(destinationAirport.Latitude, destinationAirport.Longitude);

                var distance = departCoord.GetDistanceTo(destCoord);
                param.FlightDistance = distance;

                //calculate the fuel needed for this flight:
                double fuelNeeded = param.AirCratfFuelComsumpDistance * param.FlightTime + param.TakeOffEffort;
                param.FuelNeeded = fuelNeeded;
                

                _flightBLL.AddFlight(param);

                returnValue =  new ResponseModel { Code = "OK", Message = "OK" };
            }
            catch (Exception ex)
            {
                returnValue =  new ResponseModel { Code = "KO", Message = ex.Message };

            }
            return returnValue;
        }

        /// <summary>
        /// Update flight Data
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(WebApiRoutes.UpdateFlightListActionName)]
        public ResponseModel UpdadteFlight([FromBody] Flight param)
        {

            var _flightBLL = FlightBLL.Instance;

            Flight flight = _flightBLL.GetFlightsById(param.Id);
            flight.DepartureAirport_Id = param.DepartureAirport_Id;
            flight.DestinationAirport_Id = param.DestinationAirport_Id;


            var airportList = AirportBLL.Instance.GetAirportsList().ToList();
            Airport departureAirport = airportList.First(elt => elt.Id == param.DepartureAirport_Id);
            Airport destinationAirport = airportList.First(elt => elt.Id == param.DestinationAirport_Id);

            // calculate de distance betewen 2 airports using their gps positions
            var departCoord = new GeoCoordinate(departureAirport.Latitude, departureAirport.Longitude);
            var destCoord = new GeoCoordinate(destinationAirport.Latitude, destinationAirport.Longitude);

            var distance = departCoord.GetDistanceTo(destCoord);
            flight.FlightDistance = distance;
            flight.AirCratfFuelComsumpDistance = param.AirCratfFuelComsumpDistance;
            flight.FlightTime = param.FlightTime;
            flight.TakeOffEffort = param.TakeOffEffort;

            //calculate the fuel needed for this flight:
            double fuelNeeded = param.AirCratfFuelComsumpDistance * param.FlightTime + param.TakeOffEffort;
            flight.FuelNeeded = fuelNeeded;
            ResponseModel returnValue = new ResponseModel();
            try
            {
                _flightBLL.UpdateFlight(flight);

                returnValue =  new ResponseModel { Code = "OK", Message = "OK" };
            }
            catch (Exception ex)
            {
                returnValue =  new ResponseModel { Code = "KO", Message = ex.Message };
            }
            return returnValue;

        }


        /// <summary>
        /// Get flight Data by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Route(WebApiRoutes.GetFlightByIdActionName)]        
        public FlightModel GetFlightById(int Id)
        {
            var _flightBLL = FlightBLL.Instance;
            
            Flight flight = _flightBLL.GetFlightsById(Id);

            FlightModel model = new FlightModel();

            model = AutoMapper.Mapper.Map<FlightModel>(flight);
            return model;


        }

    }
}
