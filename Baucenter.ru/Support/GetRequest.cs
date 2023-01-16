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

        public Dictionary<string, string> Headers { get; set; }

        public string Respons { get; set; }
        public string Accept { get; set; }
        public string Host { get; set; }
        public string Refer { get; set; }
        public string UserAgent { get; set; }
        public WebProxy Proxy { get; set; }

        public GetRequest( string adress)
        {
            _adress = adress;
            Headers = new Dictionary<string, string>();
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
        public void Run(CookieContainer cookieContainer)
        {
            _request = (HttpWebRequest)WebRequest.Create(_adress);
            _request.Method = "GET";
            _request.CookieContainer = cookieContainer;
            _request.Proxy = Proxy;
            _request.Accept = Accept;
            _request.Host = Host;
            _request.Referer = Refer;
            _request.UserAgent = UserAgent;


            foreach(var pair in Headers)
            {
                _request.Headers.Add(pair.Key, pair.Value);
            }
            try
            {
                HttpWebResponse response = (HttpWebResponse)_request.GetResponse();
                var stream = response.GetResponseStream();
                if (stream != null)
                {
                    Respons = new StreamReader(stream).ReadToEnd();
                }
            }
            catch (Exception)
            {
            }

        }
    }  
}
