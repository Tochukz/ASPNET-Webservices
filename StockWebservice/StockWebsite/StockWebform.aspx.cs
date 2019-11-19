using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StockWebsite
{
    public partial class StockWebform : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblmessage.Text = "First Loading Time: " + DateTime.Now.ToLongTimeString();
            }
            else
            {
                lblmessage.Text = "PostBack at: " + DateTime.Now.ToLongTimeString();
            }
        }
        protected void btnservice_Click(object sender, EventArgs e)
        {
            StockServiceReference.StockServiceSoapClient proxy = new StockServiceReference.StockServiceSoapClient();
            lblmessage.Text = String.Format("Current SATYAM Price:{0}", proxy.GetPrice("SATYAM").ToString());
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Do nothing
        }
    }
}