using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebServicesDemo
{
    /// <summary>
    /// Summary description for CalculatorWebService
    /// </summary>
    [WebService(Namespace = "http://mywebstation/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.None)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CalculatorWebService : System.Web.Services.WebService
    {
        [WebMethod(EnableSession=true, Description="This method adds 2 numbers", CacheDuration=20)]
        public int Add(int firstNumber, int secondNumber)
        {
            List<string> calculations;

            if( Session["CALCULATIONS"] == null)
            {
                calculations = new List<string>();
            }
            else
            {
                calculations = (List<string>) Session["CALCULATIONS"];
            }

            int total = firstNumber + secondNumber;
            
            string newCalculation = firstNumber.ToString() + " + " + secondNumber.ToString() + " = " + total.ToString(); 
            calculations.Add(newCalculation);
            Session["CALCULATIONS"] = calculations;

            return total;
        }

        [WebMethod(MessageName ="Add3Numbers")]
        public int Add(int firstNumber, int secondNumber, int thirdNumber)
        {
            return firstNumber + secondNumber + thirdNumber;
        }
        [WebMethod(EnableSession = true)]
        public List<string> GetCalculations()
        {
            if (Session["CALCULATIONS"] == null)
            {
                List<string> calculations = new List<string>();
                calculations.Add("You have not done any calculation");
                return calculations;
            }
            else
            {
                List<string> calculations = (List<string>)Session["CALCULATIONS"];
                return calculations;
            }
        }
    }
}
