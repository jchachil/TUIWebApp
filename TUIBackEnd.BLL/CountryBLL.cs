using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUIBackEnd.DAL;

namespace TUIBackEnd.BLL
{
    /// <summary>
    /// Country BLL Class
    /// </summary>
    public class CountryBLL
    {

        #region Singlton
        private static CountryBLL instance;
        /// <summary>
        /// Private constructor to prevent instance creation.
        /// </summary>
        private CountryBLL()
        {

        }
        /// <summary>
        /// Singlton.
        /// </summary>
        public static CountryBLL Instance
        {
            get
            {
                // If the instance is null then create one and init the Queue
                if (instance == null)
                {
                    instance = new CountryBLL();
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
        /// /// Get all countries from Database
        /// </summary>
        /// <returns></returns>
        public List<Country> GetCountriesList()
        {
            return Data.Countries.ToList();
        }
    }
}
