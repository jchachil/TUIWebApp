using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TUIFront.Areas.TUIFlight.Models
{
    public class FlightModel
    {
        public int Id { get; set; }
        //public string FlightName { get; set; }

        //public DateTime? FlightDate { get; set; }

        public int DepartureAirport_Id { get; set; }

        public int DestinationAirport_Id { get; set; }
        
        public double FlightDistance { get; set; }

        [Required(ErrorMessage = "The field AirCraft fuel comsumption per distance  is required")]
        public decimal AirCratfFuelComsumpDistance { get; set; }

        [Required(ErrorMessage = "The field FlightTime Effort is required")]
        public decimal FlightTime { get; set; }

        [Required( ErrorMessage = "The field TakeOff Effort is required")]
        public decimal TakeOffEffort { get; set; }
        public decimal FuelNeeded { get; set; }

        public List<System.Web.Mvc.SelectListItem> DepartCountries { get; set; }
        public List<System.Web.Mvc.SelectListItem> DestinationCountries { get; set; }

        public List<System.Web.Mvc.SelectListItem> DepartAirports { get; set; }
        public List<System.Web.Mvc.SelectListItem> DestinationAirports { get; set; }

        public string SelectedDepCountryId { get; set; }
        public string SelectedDestCountryId { get; set; }

        public AirportModel Airport { get; set; }
        public AirportModel Airport1 { get; set; }


        public string  DepartureCountryName { get; set; }
        public string  DestinationCountryName { get; set; }
    }
}