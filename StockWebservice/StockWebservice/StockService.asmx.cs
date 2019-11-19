using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace StockWebservice
{
    /// <summary>
    /// Summary description for StockService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class StockService : System.Web.Services.WebService
    {
        public StockService()
        {
            //Uncomment the following if using design component
            //InitializeComponent();
        }

        // A two dimensional array of strings fot stock symbol, name and price
        string[,] stock =
        {
            {"RELIND", "Reliance Industries", "1060.15"},
            {"ICICI", "ICICI Bank", "911.55"},
            {"JSW", "JSW Steel", "1201.25"},
            {"WIPRO", "Wipro Limited", "1194.65"},
            {"SATYAM", "Satyam Computers", "91.10"}
        };

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public double GetPrice(string symbol)
        {
            // it takes the symbol as parameter and returns price 
            for (int i = 0; i < stock.GetLength(0); i++)
            {
                if (String.Compare(symbol, stock[i, 0], true) == 0)
                    return Convert.ToDouble(stock[i, 2]);
            }

            return 0;
        }

        [WebMethod]
        public string GetName(string symbol)
        {
            // It takes the symbol as parameter and returns name of the stock
            for (int i = 0; i < stock.GetLength(0); i++)
            {
                if (String.Compare(symbol, stock[i, 0], true) == 0)
                    return stock[i, 1];
            }
            return "Stock Not Found";
        }
    }
}
