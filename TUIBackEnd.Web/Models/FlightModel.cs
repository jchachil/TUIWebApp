using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TUIBackEnd.Models
{
    /// <summary>
    /// Flight Model class
    /// </summary>
    public class FlightModel
    {
        public int Id { get; set; }

        public int DepartureAirport_Id { get; set; }

        public int DestinationAirport_Id { get; set; }

        public double FlightDistance { get; set; }

        public double AirCratfFuelComsumpDistance { get; set; }

        public double FlightTime { get; set; }

        public double TakeOffEffort { get; set; }

        public double FuelNeeded { get; set; }

        public AirportModel Airport { get; set; }
        public AirportModel Airport1 { get; set; }



    }
}