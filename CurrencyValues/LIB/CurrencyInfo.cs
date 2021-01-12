using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace CurrencyValues
{
    public class CurrencyInfo
    {
        public Dictionary<string,double> rates;
        
        [JsonProperty(PropertyName = "base")]
        public string cBase;

        [JsonProperty(PropertyName = "date")]
        public string cdate;
    }
}