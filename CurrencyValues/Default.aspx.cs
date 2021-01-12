using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CurrencyValues
{
    public partial class Default : System.Web.UI.Page
    {
        public ExchangeRates exr = new ExchangeRates();

        protected void Page_Load(object sender, EventArgs e)
        {
            //get the information from the disk and display it.
            exr.GetSavedInformation();

            // check if there is something to display
            if (exr.Pairs != null)
            {
                if (exr.Pairs.Count > 0)
                {
                    gvExchangeRates.DataSource = exr.Pairs;
                    gvExchangeRates.DataBind();

                    lblRetrieveDate.Text = exr.retrieveTime.ToString();
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            exr.UpdateExhcnageRates();

            // check if there is something to display
            if (exr.Pairs != null)
            {
                if (exr.Pairs.Count > 0)
                {
                    gvExchangeRates.DataSource = exr.Pairs;
                    gvExchangeRates.DataBind();

                    lblRetrieveDate.Text = exr.retrieveTime.ToString();
                }
            }
        }
    }
}