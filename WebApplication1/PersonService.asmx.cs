using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    /// <summary>
    /// Summary description for PersonService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    [ScriptService]
    public class PersonService : System.Web.Services.WebService
    {
        public string connectionString;

        [WebMethod]
        public void AddPerson(string per)
        {
            Person person = JsonConvert.DeserializeObject<Person>(per);

            string connectionString = ConfigurationManager.ConnectionStrings["Preson"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sppersonCrud", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@FirstName",
                    Value = person.FirstName
                });
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@MiddleName",
                    Value = person.MiddleName
                });
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@LastName",
                    Value = person.LastName
                });
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@MoblieNumber",
                    Value = person.Mobile
                });
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Address",
                    Value = person.Address
                });
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Country",
                    Value = person.Country
                });
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@State",
                    Value = person.State
                });
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@City",
                    Value = person.City
                });
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@PinCode",
                    Value = person.Pincode
                });
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@DateOfBrith",
                    Value = person.birthday
                });
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Gender",
                    Value = person.Gender
                });
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Hobbies",
                    Value = person.Hobbies
                });

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        
        [WebMethod]
        public void getCountry()
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("spGetCountry", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            //List<Country>
            
        }
    }
}
