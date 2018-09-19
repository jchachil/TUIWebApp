using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUIBackEnd.DAL;


namespace TUIBackEnd.BLL
{
    /// <summary>
    /// Flight BLL Class
    /// </summary>
    public class FlightBLL
    {


        #region Singlton
        private static FlightBLL instance;
        /// <summary>
        /// Private constructor to prevent instance creation.
        /// </summary>
        private FlightBLL()
        {

        }
        /// <summary>
        /// Singlton.
        /// </summary>
        public static FlightBLL Instance
        {
            get
            {
                // If the instance is null then create one and init the Queue
                if (instance == null)
                {
                    instance = new FlightBLL();
                }
                return instance;
            }
        }
        #endregion

        private TUIWebAppEntities _Data = null;
        protected TUIWebAppEntities Data
        {
            get
            {
                if (_Data == null)
                {
                    _Data = new TUIWebAppEntities();
                }

                return _Data;
            }
        }


        /// <summary>
        /// Get all flights data from DB
        /// </summary>
        /// <returns></returns>
        public List<Flight> GetFlightsList()
        {
            return Data.Flights.ToList();
        }

        /// <summary>
        /// Get Flight By Id from database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Flight GetFlightsById(int id)
        {
            return Data.Flights.FirstOrDefault(elt=>elt.Id== id);
        }

        /// <summary>
        /// Add Flight to database
        /// </summary>
        /// <param name="flight"></param>
        public void AddFlight(Flight flight)
        {
            Data.Flights.Add(flight);
            Data.SaveChanges();
        }

        /// <summary>
        /// Update Flight
        /// </summary>
        /// <param name="flight"></param>
        public void UpdateFlight(Flight flight)
        {
            Data.Flights.Find(flight.Id);
            Data.SaveChanges();
        }


    }
}
