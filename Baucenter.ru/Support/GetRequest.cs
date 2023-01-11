using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Cache;
using System.Configuration;

namespace CatalogSupportLibrary.Requests
{
    public class GetRequest
    {
        HttpWebRequest _request;
        string _adress;

        public string Respons { get; set; }

        public GetRequest( string adress)
        {
            _adress = adress;
        }

        public void Run()
        {
            _request =(HttpWebRequest)WebRequest.Create(_adress);
            _request.Method = "GET";

            try
            {
                HttpWebResponse response = (HttpWebResponse)_request.GetResponse();
                var stream = response.GetResponseStream();
                if (stream != null)
                {
                    Respons = new StreamReader(stream).ReadToEnd();
                }
            }
            catch(Exception)
            {
            }
           
        }
    }  
}
