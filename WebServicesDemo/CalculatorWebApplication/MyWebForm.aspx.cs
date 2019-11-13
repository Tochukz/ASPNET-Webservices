using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CalculatorWebApplication
{
    public partial class MyWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            CalculatorService.CalculatorWebServiceSoapClient client = new CalculatorService.CalculatorWebServiceSoapClient();
            int firstNumber = Convert.ToInt32(txtFirstNumber.Text);
            int secondNumber = Convert.ToInt32(txtSecondNumber.Text);
            int result = client.Add(firstNumber, secondNumber);
            lblResult.Text = result.ToString();

            gvCalculations.DataSource = client.GetCalculations();
            gvCalculations.DataBind();

            gvCalculations.HeaderRow.Cells[0].Text = "Recent Calculations";
        }
    }
}