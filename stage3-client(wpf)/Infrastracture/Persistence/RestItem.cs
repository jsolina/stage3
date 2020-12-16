using System;
using System.IO;
using System.Net;
using System.Text;
using System.Collections.Generic;
using Domain.Models;
using Newtonsoft.Json;

namespace Infrastracture.Persistence
{
    public class RestItem
    {
        public string endPoint = "http://localhost:5001/api/itemlist";
        public httpVerb httpMethod { get; set; }

        public string postJSON { get; set; }
        public Item Items { get; set; }

        public RestItem()
        {
            //endPoint = "";
        }

        public IEnumerable<Item> GetRequest()
        {
            string strJSON = string.Empty;
            httpMethod = httpVerb.GET;
            strJSON = MakeRequest();

            var rawJson = strJSON + Environment.NewLine;
            var deserializeJson = JsonConvert.DeserializeObject<List<Item>>(rawJson);
            return deserializeJson;
        }
        public string PostRequest(Item Items)
        {
            SerializeObject(Items);
            httpMethod = httpVerb.POST;
            return MakeRequest();
        }

        public void DeleteRequest(Item Items)
        {
            /*
            WebRequest request = WebRequest.Create(endPoint);
            httpMethod = httpVerb.DELETE;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            */
        }

        public string PutRequest(Item Items)
        {
            SerializeObject(Items);
            httpMethod = httpVerb.PUT;
            return MakeRequest();
        }

        public string SerializeObject(Item Items)
        {
            return postJSON = JsonConvert.SerializeObject(Items, Formatting.Indented);
        }

        public string MakeRequest()
        {
            string strResponseValue = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);

            request.Method = httpMethod.ToString();

            if ((request.Method == "POST" || request.Method == "PUT") && postJSON != string.Empty)
            {
                request.ContentType = "application/json";
                using (StreamWriter swJsonPayLoad = new StreamWriter(request.GetRequestStream()))
                {
                    swJsonPayLoad.Write(postJSON);
                    swJsonPayLoad.Close();
                }
            }

            HttpWebResponse response = null;

            try
            {
                response = (HttpWebResponse)request.GetResponse();

                //Proecess the resppnse stream... (could be JSON, XML or HTML etc..._

                using (Stream responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            strResponseValue = reader.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                strResponseValue = "{\"errorMessages\":[\"" + ex.Message.ToString() + "\"],\"errors\":{}}";
            }
            finally
            {
                if (response != null)
                {
                    ((IDisposable)response).Dispose();
                }
            }

            return strResponseValue;
        }

    }
}
