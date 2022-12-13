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
using WebApplication1.Classes;

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
        public string connectionString = ConfigurationManager.ConnectionStrings["Preson"].ConnectionString;

        [WebMethod]
        public void AddPerson(string per)
        {
            Person person = JsonConvert.DeserializeObject<Person>(per);

            //string connectionString = ConfigurationManager.ConnectionStrings["Preson"].ConnectionString;
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
                con.Close();
            }
        }
        [WebMethod]
        [ScriptMethod]
        public List<Country> GetCountries()
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("spGetCountry", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            sda.Fill(dt);

            List<Country> lst = new List<Country>();
            foreach (DataRow dr in dt.Rows)
            {
                lst.Add(new Country() { CountryId = Convert.ToInt32(dr["CountryId"]), CountryName = Convert.ToString(dr["CountryName"]) });
            }
            return lst;

        }
        [WebMethod]
        [ScriptMethod]
        public List<State> GetState(string CounrtyId)
        {

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("spGetStateByCountry", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CountryId", CounrtyId);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            List<State> lst = new List<State>();
            foreach (DataRow dr in dt.Rows)
            {
                lst.Add(new State() { StateId = Convert.ToInt32(dr["StateId"]), StateName = Convert.ToString(dr["StateName"])});
            }
            return lst;
        }

        [WebMethod]
        [ScriptMethod]
        public List<City> GetCity(String StateId) 
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("spGetCityByStateId", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StateId", StateId);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            List<City> lst = new List<City>();
            foreach (DataRow dr in dt.Rows) 
            {
                lst.Add(new City() { CityId = Convert.ToInt32(dr["CityId"]), CityName = Convert.ToString(dr["CityName"]) });
            }
            return lst;
        }
    }
}
