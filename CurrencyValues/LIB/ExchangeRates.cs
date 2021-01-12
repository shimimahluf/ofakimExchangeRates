using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace CurrencyValues
{
    public class ExchangeRates
    {
        public Dictionary<string, double> Pairs;
        public DateTime retrieveTime;

        /// <summary>
        /// Gets the information that is currently saved on the disk.
        /// </summary>
        public void GetSavedInformation()
        {
            if (File.Exists(HttpRuntime.AppDomainAppPath + "data.txt"))
            {
                string data = System.IO.File.ReadAllText(HttpRuntime.AppDomainAppPath + "data.txt");

                ExchangeRates tmp = JsonConvert.DeserializeObject<ExchangeRates>(data);

                if (tmp != null)
                {
                    this.Pairs = tmp.Pairs;
                    this.retrieveTime = tmp.retrieveTime;
                }

            }
        }


        /// <summary>
        /// Get updated information from an API, save it to the disk and update the public members.
        /// </summary>
        public void UpdateExhcnageRates()
        {

            // Make sure there is a reason to call the API (there are pair we are interested in)
            if (File.Exists(HttpRuntime.AppDomainAppPath + "Pairs.txt"))
            {
                // read the pairs we are interested to show from pairs.txt
                // the file syntax should be each line BASE_CURRENCY/TARGET_CURRENCY
                string[] pairs = System.IO.File.ReadAllLines(HttpRuntime.AppDomainAppPath + "Pairs.txt");

                if (pairs.Length>0)
                {
                    // Open a request to the api and deserialize the json to a usable class.
                    string ExJson = sRequest.RequestURL(ConfigurationManager.AppSettings["ExRatesAPI"]);
                    CurrencyInfo ci = new CurrencyInfo();
                    ci = JsonConvert.DeserializeObject<CurrencyInfo>(ExJson);

                    // loop through the pairs and get the values we want. Note: we get the currencies in USD base, conversion needed.
                    Dictionary<string, double> newpairs = new Dictionary<string, double>();
                    foreach (string item in pairs)
                    {
                        string[] pair = item.Split('/');

                        // to covert the value from USD to the base we want: 1/TARGET_BASE. The Value of the TARGET_CURRENCY = NEW_BASE * TARGET_VALUE_USD_BASE
                        double target_base = 1 / ci.rates[pair[0]];
                        double target_currency = target_base * ci.rates[pair[1]];

                        newpairs.Add(item, target_currency);
                    }

                    this.Pairs = newpairs;
                    this.retrieveTime = DateTime.Now;
                    SaveToDisk();
                }

            }
            
        }


        /// <summary>
        /// Saves the current data to a file in the disk.
        /// </summary>
        private void SaveToDisk()
        {
            string data = JsonConvert.SerializeObject(this);
            File.WriteAllText(HttpRuntime.AppDomainAppPath + "data.txt", data);
        }
    }
}