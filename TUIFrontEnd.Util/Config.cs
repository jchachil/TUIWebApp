using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web;


namespace TUIFrontEnd.Util
{
    /// <summary>
    /// this class contains ressources retrived from web.config
    /// </summary>
    public class Config
    {
        public static string RessourceEndPoint
        {
            get
            {
                try
                {
                    return System.Web.Configuration.WebConfigurationManager.AppSettings["RessourceEndPoint"].ToString();
                }
                catch
                {
                    return string.Empty;
                }

            }
        }
    }
}
