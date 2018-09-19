using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TUIFrontEnd.Util
{
    /// <summary>
    /// this class is used to call web api
    /// </summary>
    public class WebApiCaller
    {      
       
        /// <summary>
        /// Call post method from web api
        /// </summary>
        /// <param name="clientURL"></param>
        /// <param name="rsEndPoint"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static HttpResponseMessage CallSyncStatement(string clientURL, string rsEndPoint, string parameters)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(clientURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                response = client.PostAsync(rsEndPoint, new StringContent(parameters, Encoding.UTF8, "application/json")).Result;
            }

           
            return response;
        }

        /// <summary>
        /// Call get method from web api
        /// </summary>
        /// <param name="clientURL"></param>
        /// <param name="rsEndPoint"></param>
        /// <returns></returns>
        public static HttpResponseMessage RunGetSyncStatement(string clientURL, string rsEndPoint)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(clientURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                response = client.GetAsync(rsEndPoint).Result;
            }
           
            return response;
        }


        public static HttpResponseMessage RunSyncStatement(string clientURL, string rsEndPoint, FormUrlEncodedContent parameters)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(clientURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
                response = client.PostAsync(rsEndPoint, parameters).Result;
            }
            
            return response;
        }


    }
}
