using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUIBackEnd.DAL;

namespace TUIBackEnd.BLL
{
    /// <summary>
    /// Airport BLL class
    /// </summary>
    public class AirportBLL
    {

        #region Singlton
        private static AirportBLL instance;
        /// <summary>
        /// Private constructor to prevent instance creation.
        /// </summary>
        private AirportBLL()
        {

        }
        /// <summary>
        /// Singlton.
        /// </summary>
        public static AirportBLL Instance
        {
            get
            {
                // If the instance is null then create one and init the Queue
                if (instance == null)
                {
                    instance = new AirportBLL();
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
        /// Get all Airports from Database
        /// </summary>
        /// <returns></returns>
        public List<Airport> GetAirportsList()
        {
            return Data.Airports.ToList();
        }
    }
}
