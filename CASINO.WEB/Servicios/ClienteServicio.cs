using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web.Script.Serialization;

namespace CASINO.WEB.Servicios
{
    public class ClienteServicio
    {
        static HttpClient client = new HttpClient();
        public List<cliente> GetClientes()
        {
            var url = $"http://localhost:54595/api/clientes";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return null;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();

                            JavaScriptSerializer serializer = new JavaScriptSerializer();
                            List<cliente> clientes = serializer.Deserialize<List<cliente>>(responseBody);

                            return clientes;
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle error
                return null;
            }
        }


    }
}