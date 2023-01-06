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
using System.Web.Script.Serialization;

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
                result.error = "FirstName in Maximum 50 characters allowed.";
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
                result.error = "MiddleName in Maximum 50 characters allowed.";
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
                result.error = "LastName in Maximum 50 characters allowed.";
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

            //--------------- Moblie Number ----------------
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

            SqlConnection conMoblie = new SqlConnection(connectionString);
            SqlCommand cmdMoblie = new SqlCommand("sppersonSelectedbyMobile", conMoblie);
            conMoblie.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmdMoblie);
            cmdMoblie.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            cmdMoblie.Parameters.AddWithValue("@MoblieNumber", person.Mobile);
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                result.success = false;
                result.error = "Enter the Different Moblie Number.";
                return result;
            }

            //---------- Address ---------
            if (string.IsNullOrWhiteSpace(person.Address))
            {
                result.success = false;
                result.error = "Address should be required.";
                return result;
            }
            if (person.Address.Length > 200)
            {
                result.success = false;
                result.error = "Only Enter 200 character in Address.";
                return result;
            }
            //string address = @"^[ A-Za-z0-9]$";
            //Regex Address = new Regex(address);
            //if (!Address.IsMatch(person.Address))
            //{
            //    result.success = false;
            //    result.error = "Enetr alphanumeric, dash, underscore are allowed.";
            //    return result;
            //}

            //----------- Country ---------
            if (person.Country == "0")
            {
                result.success = false;
                result.error = "Select Country.";
                return result;
            }

            //--------- State----------
            if (person.State == "0")
            {
                result.success = false;
                result.error = "Select State.";
                return result;
            }

            //--------- City----------
            if (person.City == "0")
            {
                result.success = false;
                result.error = "City State.";
                return result;
            }

            //---------- Pin Code --------
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


            //---------- date of brithday -------------
            if (string.IsNullOrEmpty(person.Birthday))
            {
                result.success = false;
                result.error = "Date Of Brith should be required.";
                return result;
            }
            var today = DateTime.Today;
            var age = today.Year - Convert.ToDateTime(person.Birthday).Year;
            if (Convert.ToDateTime(person.Birthday).Date > today.AddYears(-age)) age--;
            if (age < 18 || age > 200)
            {
                result.success = false;
                result.error = "Age should be more than 18.";
                return result;
            }

            //----------- Gender ---------
            if (string.IsNullOrEmpty(person.Gender))
            {
                result.success = false;
                result.error = "Gender should be required.";
                return result;
            }

            //------------ Hobbies ------------
            if (string.IsNullOrEmpty(person.Hobbies))
            {
                result.success = false;
                result.error = "Hobbies should be required.";
                return result;
            }
            if (person.Hobbies.Split(',').Length < 3)
            {
                result.success = false;
                result.error = "Minimun 3 Selected Hobbies";
                return result;
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
                    Value = person.Birthday
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
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@TermsAndConditions",
                    Value = person.TermsAndConditions
                });
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@DMLFlag",
                    Value = "I"
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

        //Country Dropdown 
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

        //State Dropdown
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

        //City Dropdown 
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

        //data gridview 
        [WebMethod]
        [ScriptMethod]
        public void DataDisplay()
        {
            SqlConnection con = new SqlConnection(connectionString);
            string select = "sppersonSelected";
            SqlCommand cmd = new SqlCommand(select, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sda.Fill(dt);
            con.Close();
            //Serialize table 
            Context.Response.Write(JsonConvert.SerializeObject(dt));
        }

        // FilltheData on form
        [WebMethod]
        [ScriptMethod]
        public string FilltheData(string Pid)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("sppersonSelectedbyId", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            cmd.Parameters.AddWithValue("@Pid", Pid);
            //cmd.Parameters.AddWithValue("@PRID", PRId);
            sda.Fill(dt);
            con.Close();
            return JsonConvert.SerializeObject(dt);
        }


        //update record code
        [WebMethod]
        [ScriptMethod]
        public Result UpdateRecord(string per) 
        {
            Result result = new Result();
            Person person = JsonConvert.DeserializeObject<Person>(per);

            SqlConnection db = new SqlConnection(connectionString);
            string update = "sppersonUpdate";
            db.Open();
            SqlCommand cmdupdate = new SqlCommand(update, db);
            cmdupdate.CommandType = CommandType.StoredProcedure;

            /*----------------------------------------------------*/
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
                result.error = "FirstName in Maximum 50 characters allowed.";
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
                result.error = "MiddleName in Maximum 50 characters allowed.";
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
                result.error = "LastName in Maximum 50 characters allowed.";
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

            //--------------- Moblie Number ----------------
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

            //SqlConnection conMoblie = new SqlConnection(connectionString);
            //SqlCommand cmdMoblie = new SqlCommand("sppersonSelectedbyMobile", conMoblie);
            //conMoblie.Open();
            //SqlDataAdapter sda = new SqlDataAdapter(cmdMoblie);
            //cmdMoblie.CommandType = CommandType.StoredProcedure;
            //DataTable dt = new DataTable();
            //cmdMoblie.Parameters.AddWithValue("@MoblieNumber", person.Mobile);
            //sda.Fill(dt);
            //if (dt.Rows.Count > 0)
            //{
            //    result.success = false;
            //    result.error = "Enter the Different Moblie Number.";
            //    return result;
            //}

            //---------- Address ---------
            if (string.IsNullOrWhiteSpace(person.Address))
            {
                result.success = false;
                result.error = "Address should be required.";
                return result;
            }
            if (person.Address.Length > 200)
            {
                result.success = false;
                result.error = "Only Enter 200 character in Address.";
                return result;
            }

            //----------- Country ---------
            if (person.Country == "0")
            {
                result.success = false;
                result.error = "Select Country.";
                return result;
            }

            //--------- State----------
            if (person.State == "0")
            {
                result.success = false;
                result.error = "Select State.";
                return result;
            }

            //--------- City----------
            if (person.City == "0")
            {
                result.success = false;
                result.error = "City State.";
                return result;
            }

            //---------- Pin Code --------
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


            //---------- date of brithday -------------
            if (string.IsNullOrEmpty(person.Birthday))
            {
                result.success = false;
                result.error = "Date Of Brith should be required.";
                return result;
            }
            var today = DateTime.Today;
            var age = today.Year - Convert.ToDateTime(person.Birthday).Year;
            if (Convert.ToDateTime(person.Birthday).Date > today.AddYears(-age)) age--;
            if (age < 18 || age > 200)
            {
                result.success = false;
                result.error = "Age should be more than 18.";
                return result;
            }

            //----------- Gender ---------
            if (string.IsNullOrEmpty(person.Gender))
            {
                result.success = false;
                result.error = "Gender should be required.";
                return result;
            }

            //------------ Hobbies ------------
            if (string.IsNullOrEmpty(person.Hobbies))
            {
                result.success = false;
                result.error = "Hobbies should be required.";
                return result;
            }
            if (person.Hobbies.Split(',').Length < 3)
            {
                result.success = false;
                result.error = "Minimun 3 Selected Hobbies";
                return result;
            }



            //cmdupdate.Parameters.AddWithValue("@Pid", Pid);
            cmdupdate.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@Pid",
                Value = person.Pid
            });
            cmdupdate.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@FirstName",
                Value = person.FirstName
            });
            cmdupdate.Parameters.Add(new SqlParameter() 
            {
                ParameterName= "@MiddleName",
                Value = person.MiddleName
            }); 
            cmdupdate.Parameters.Add(new SqlParameter()
            {
                ParameterName= "@LastName",
                Value = person.LastName
            });
            cmdupdate.Parameters.Add(new SqlParameter()
            {
                ParameterName= "@MoblieNumber",
                Value = person.Mobile
            });
            cmdupdate.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@Address",
                Value = person.Address
            });
            cmdupdate.Parameters.Add(new SqlParameter()
            {
                ParameterName= "@Country",
                Value = person.Country
            });
            cmdupdate.Parameters.Add(new SqlParameter()
            {
                ParameterName= "@State",
                Value = person.State
            });
            cmdupdate.Parameters.Add(new SqlParameter()
            {
                ParameterName= "@City",
                Value = person.City
            });
            cmdupdate.Parameters.Add(new SqlParameter()
            {
                ParameterName= "@Pincode",
                Value = person.Pincode
            });
            cmdupdate.Parameters.Add(new SqlParameter()
            {
                ParameterName= "@DateOfBrith",
                Value = person.Birthday
            });
            cmdupdate.Parameters.Add(new SqlParameter()
            {
                ParameterName= "@Gender",
                Value = person.Gender
            });
            cmdupdate.Parameters.Add(new SqlParameter()
            {
                ParameterName = "@Hobbies",
                Value = person.Hobbies
            });
            
            int resultQuery = cmdupdate.ExecuteNonQuery();
            if (resultQuery == 1)
            {
                result.success = true;
            }
            return result;
        }

        //Record Delete
        [WebMethod]
        [ScriptMethod]
        public void DeleteRecord(string Pid)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("sppersonDelete", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            cmd.Parameters.AddWithValue("@Pid", Pid);
            cmd.ExecuteNonQuery();
            sda.Fill(dt);
            con.Close();

            DataDisplay();
        }
    }
}
