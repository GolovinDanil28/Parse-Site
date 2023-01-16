using CatalogSupportLibrary.Requests;
using System;

namespace Baucenter.ru
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var postRequest = new PostRequest("https://baucenter.ru/");
            postRequest.Data = "";

            postRequest.Accept = "";

            postRequest.UserAgent = "";

            postRequest.ContentType = "";

            postRequest.Headers.Add("","");
            postRequest.Refer = "";
            postRequest.Headers.Add("", "");

            postRequest.Run();
        }
    }
}
