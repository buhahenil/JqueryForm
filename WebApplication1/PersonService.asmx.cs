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
using System.Text.RegularExpressions;

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
        private object birthday;

        [WebMethod]
        public Result AddPerson(string per)
        {
            Result result = new Result();
            Person person = JsonConvert.DeserializeObject<Person>(per);

            //validetion for this code.

            // FirstName
            if (string.IsNullOrWhiteSpace(person.FirstName))
            {
                result.success = false;
                result.error = "FirstName should be required.";
                return result;
            }
            if (person.FirstName.Length > 50)
            {
                result.success = false;
                result.error = "Maximum 50 characters allowed.";
                return result;
            }
            string strRegex = @"(^[A-Z a-z]*$)";
            Regex re = new Regex(strRegex);
            if (!re.IsMatch(person.FirstName))
            {
                result.success = false;
                result.error = "Enter the Only alphabets for FirstName.";
                return result;
            }

            //MiddleName...
            if (person.MiddleName.Length > 50)
            {
                result.success = false;
                result.error = "Maximum 50 characters allowed.";
                return result;
            }
            string middlename = @"(^[A-Z a-z]*$)";
            Regex mddname = new Regex(middlename);
            if (!mddname.IsMatch(person.MiddleName))
            {
                result.success = false;
                result.error = "Enter the Only alphabets for MiddleName.";
                return result;
            }

            //LastName 
            if (string.IsNullOrWhiteSpace(person.LastName))
            {
                result.success = false;
                result.error = "LastName should be required.";
                return result;
            }
            if (person.LastName.Length > 50)
            {
                result.success = false;
                result.error = "Maximum 50 characters allowed.";
                return result;
            }
            string lastname = @"(^[A-Z a-z]*$)";
            Regex Lastname = new Regex(lastname);
            if (!Lastname.IsMatch(person.LastName))
            {
                result.success = false;
                result.error = "Enter the Only alphabets for LastName.";
                return result;
            }

            // Moblie Number 
            if (string.IsNullOrWhiteSpace(person.Mobile))
            {
                result.success = false;
                result.error = "Moblie Number should be required.";
                return result;
            }
            if (person.Mobile.Length < 10)
            {
                result.success = false;
                result.error = "only enter 10 digit moblie number.";
                return result;
            }
            string moblie = @"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$";
            Regex moblienum = new Regex(moblie);
            if (!moblienum.IsMatch(person.Mobile))
            {
                result.success = false;
                result.error = "Enter Only Number For Moblie Number.";
                return result;
            }

            // Address.....
            if (string.IsNullOrWhiteSpace(person.Address))
            {
                result.success = false;
                result.error = "Address should be required.";
                return result;
            }
            if (person.Address.Length > 200)
            {
                result.success = false;
                result.error = "Only Enter 200 character.";
                return result;
            }

            // Country......
            if (person.Country == "0")
            {
                result.success = false;
                result.error = "Select Country.";
                return result;
            }

            // State.....
            if (person.State == "0")
            {
                result.success = false;
                result.error = "Select State.";
                return result;
            }

            // City........
            if (person.City == "0")
            {
                result.success = false;
                result.error = "City State.";
                return result;
            }

            //Pin Code
            if (string.IsNullOrWhiteSpace(person.Pincode))
            {
                result.success = false;
                result.error = "PinCode should be required.";
                return result;
            }
            string pincode = @"^[1-9][0-9]{5}$";
            Regex Pincode = new Regex(pincode);
            if (!Pincode.IsMatch(person.Pincode))
            {
                result.success = false;
                result.error = "Enetr only 6 Digit.";
                return result;
            }
            //if (person.Pincode.Length < 6)
            //{
            //    result.success = false;
            //    result.error = "Enetr only 6 Digit";
            //    return result;
            //}


            // date of brithday
            if (string.IsNullOrEmpty(person.birthday))
            {
                result.success = false;
                result.error = "Date Of Brith should be required.";
                return result;
            }
            var today = DateTime.Today;
            var age = today.Year - Convert.ToDateTime(person.birthday).Year;
            if (Convert.ToDateTime(person.birthday).Date > today.AddYears(-age)) age--;
            if (age < 18 || age > 200)
            {
                result.success = false;
                result.error = "Age should be more than 18.";
                return result;
            }
           
            // Gender
            if (string.IsNullOrEmpty(person.Gender))
            {
                result.success = false;
                result.error = "Gender should be required.";
                return result;
            }

            // Hobbies
            if (string.IsNullOrEmpty(person.Hobbies))
            {
                int selectedCnt = 0;
                for (int i = 0; i < person.Hobbies.Length; i++)
                {
                    if (person.Hobbies[i].)
                    {
                        selectedCnt++;
                    }
                }

                if (selectedCnt < 3)
                {
                    result.success = false;
                    result.error = "Minimun 3 Selected";
                    return result;
                }
            }


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
                int resultQuery = cmd.ExecuteNonQuery();
                con.Close();

                if (resultQuery == 1)
                {
                    result.success = true;
                }

                return result;
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
                lst.Add(new State() { StateId = Convert.ToInt32(dr["StateId"]), StateName = Convert.ToString(dr["StateName"]) });
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
