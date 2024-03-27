using System.Text.Json; 
using System.Collections.Generic;
using System.IO; 
using System.Net;
using System.Net.Http; 
using System.Web.Script.Serialization;

namespace CASINO.WEB.Servicios
{
    public class FacturaServicio
    {
        static HttpClient client = new HttpClient();
        public List<factura> GetFacturas()
        {
            var url = $"http://localhost:54595/api/facturas";
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
                            List<factura> facturas = serializer.Deserialize<List<factura>>(responseBody);

                            return facturas;
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

        public factura GetFactura(int? numero_factura)
        {
            var url = $"http://localhost:54595/api/facturas/{numero_factura}";
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
                            var factura = serializer.Deserialize<factura>(responseBody);

                            return factura;
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

        public string PutFactura(int numero_factura, factura factura)
        {
            var url = $"http://localhost:54595/api/facturas/{numero_factura}";
            var request = (HttpWebRequest)WebRequest.Create(url);
            string json = JsonSerializer.Serialize(factura);
            request.Method = "PUT";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

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
                            return responseBody;
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

        public string PostFactura(int numero_factura, factura factura)
        {
            var url = $"http://localhost:54595/api/facturas/{numero_factura}";
            var request = (HttpWebRequest)WebRequest.Create(url);
            string json = JsonSerializer.Serialize(factura);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

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
                            return responseBody;
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

        public string DeleteFactura(int numero_factura)
        {
            var url = $"http://localhost:54595/api/facturas/{numero_factura}";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "DELETE";
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
                            return responseBody;
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