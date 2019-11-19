using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebServicesDemo
{
    /// <summary>
    /// Summary description for StudentService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class StudentService : System.Web.Services.WebService
    {

        [WebMethod]
        public Student GetStudentById(int ID)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString; //DBCS is the name we gave to our connection string in Web.config  
            using( SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetStudentByID", con); //spGetStudentById is our user defined stored procedure
                cmd.CommandType = CommandType.StoredProcedure; // The SqlCommand object the the command to execute is a stored procedure
                SqlParameter parameter = new SqlParameter("@ID", ID); // Passing the ID argument to the store procedure  
                cmd.Parameters.Add(parameter);
                Student student = new Student();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    student.ID = Convert.ToInt32(reader["ID"]);
                    student.Name = reader["Name"].ToString();
                    student.Gender = reader["Gender"].ToString();
                    student.TotalMarks = Convert.ToInt32(reader["TotalMarks"]);
                }
                return student;
            }
        }
    }
}
