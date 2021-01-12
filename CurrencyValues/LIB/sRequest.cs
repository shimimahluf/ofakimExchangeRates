using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace CurrencyValues
{
    public static class sRequest
    {
        public static string RequestURL(string url)
        {
            WebRequest wrGETURL;
            wrGETURL = WebRequest.Create(url);

            Stream objStream;
            objStream = wrGETURL.GetResponse().GetResponseStream();

            StreamReader objReader = new StreamReader(objStream);

            string data = objReader.ReadToEnd();

            return data;
        }
    }
}