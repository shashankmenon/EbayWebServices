using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using MySql.Data.MySqlClient;
using WebService2;


namespace WebService2
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {

        [WebMethod]
        public Boolean admin_login(String username, String password)
        {

            string MyConString = "SERVER=localhost;" +
                  "DATABASE=web_service;" +
                  "UID=root;" +
                  "PASSWORD=root;";


            string temp_username = "";
            string temp_password = "";
            using (MySqlConnection connection = new MySqlConnection(MyConString))
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("select username from admin");
                    using (MySqlDataReader Reader = command.ExecuteReader())
                    {

                        while (Reader.Read())
                        {

                            for (int i = 0; i < Reader.FieldCount; i++)
                                temp_username += Reader.GetValue(i).ToString();

                        }
                    }
                }
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("select password from admin");
                    using (MySqlDataReader Reader = command.ExecuteReader())
                    {

                        while (Reader.Read())
                        {

                            for (int i = 0; i < Reader.FieldCount; i++)
                                temp_password += Reader.GetValue(i).ToString();

                        }
                    }
                }
            }
            if (username.Equals(temp_username) == true && password.Equals(temp_password) == true)
            {
                return true;
            }
            else
            {
                return false;
                
            }
            
            
        }

        [WebMethod]
        public int register(String username, String password, String password2, String firstname, String lastname, String email, String number)
        {

            string MyConString = "SERVER=localhost;" +
                  "DATABASE=web_service;" +
                  "UID=root;" +
                  "PASSWORD=root;";
           
            
                using ( MySqlConnection connection = new MySqlConnection(MyConString))
                {
                    connection.Open();
                    using (MySqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = String.Format("select userid from customer");
                        using (MySqlDataReader Reader = command.ExecuteReader())
                        {

                            while (Reader.Read())
                            {

                                for (int i = 0; i < Reader.FieldCount; i++)
                                {
                                    String temp_username = "";
                                    temp_username += Reader.GetValue(i).ToString();
                                    if (temp_username.Equals(username) == true)
                                    {
                                        return 0;
                                    }
                                }

                            }
                        }
                        
                    }
                }
                if (password == password2)
                {
                    using ( MySqlConnection connection = new MySqlConnection(MyConString))
                    {
                       connection.Open();
                        using (MySqlCommand command = connection.CreateCommand())
                        {
                            Double p_number = Convert.ToDouble(number);
                            command.CommandText = String.Format("insert into customer values(\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\")", username
                                                                , password, firstname, lastname, number, email);

                            
                            using (MySqlDataReader Reader = command.ExecuteReader())
                            {

                               Reader.Read();
                           }
                        }
                        return 2;
                    }
                    
                }
                else
                {
                    return 3;
                }
        }
        
        [WebMethod]
        public Boolean client_login(String username, String password)
        {

            string MyConString = "SERVER=localhost;" +
                  "DATABASE=web_service;" +
                  "UID=root;" +
                  "PASSWORD=root;";


            string[] temp_username = new string[100];
            string[] temp_password = new string[100];
            int counter1 = 0;
            int counter2 = 0;
            using (MySqlConnection connection = new MySqlConnection(MyConString))
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("select userid from customer");
                    using (MySqlDataReader Reader = command.ExecuteReader())
                    {

                        while (Reader.Read())
                        {

                            for (int i = 0; i < Reader.FieldCount; i++)
                            {
                                temp_username[counter1] = Reader.GetValue(i).ToString();
                                counter1++;
                            }
                        }
                    }
                }
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("select password from customer");
                    using (MySqlDataReader Reader = command.ExecuteReader())
                    {

                        while (Reader.Read())
                        {

                            for (int i = 0; i < Reader.FieldCount; i++)
                            {
                                temp_password[counter2] = Reader.GetValue(i).ToString();
                                counter2++;
                            }

                        }
                    }
                }
            }
            for (int i = 0; i < counter1; i++)
            {
                if (username.Equals(temp_username[i]) == true && password.Equals(temp_password[i]) == true)
                {
                    return true;
                }
            }
            return false;


        }

        [WebMethod]
        public void purchase(String username, String itemID, String itemTitle)
        {

            string MyConString = "SERVER=localhost;" +
                  "DATABASE=web_service;" +
                  "UID=root;" +
                  "PASSWORD=root;";
            using (MySqlConnection connection = new MySqlConnection(MyConString))
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("insert into cust_product values(\"{0}\",\"{1}\",\"{2}\")", username
                                                                , itemID, itemTitle);
                    using (MySqlDataReader Reader = command.ExecuteReader())
                    {
                        Reader.Read();
                    }
                }
            }
        }

        [WebMethod]
        public void add_to_cart(String itemID, String itemTitle)
        {

            string MyConString = "SERVER=localhost;" +
                  "DATABASE=web_service;" +
                  "UID=root;" +
                  "PASSWORD=root;";
            using (MySqlConnection connection = new MySqlConnection(MyConString))
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("insert into addtocart values(\"{0}\",\"{1}\")",itemID, itemTitle);
                    using (MySqlDataReader Reader = command.ExecuteReader())
                    {
                        Reader.Read();
                    }
                }
            }
        }

        [WebMethod]
        public void clear_addtocart()
        {

            string MyConString = "SERVER=localhost;" +
                  "DATABASE=web_service;" +
                  "UID=root;" +
                  "PASSWORD=root;";
            using (MySqlConnection connection = new MySqlConnection(MyConString))
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("delete from addtocart");
                    using (MySqlDataReader Reader = command.ExecuteReader())
                    {
                        Reader.Read();
                    }
                }
            }
        }

        [WebMethod]
        public void add_after_buy(Object itemID, Object itemTitle, String userid, DateTime time)
        {

            string MyConString = "SERVER=localhost;" +
                  "DATABASE=web_service;" +
                  "UID=root;" +
                  "PASSWORD=root;";
            using (MySqlConnection connection = new MySqlConnection(MyConString))
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("insert into customer_history values(\"{0}\",\"{1}\",\"{2}\",\"{3}\")", userid,itemID,itemTitle,time);
                    using (MySqlDataReader Reader = command.ExecuteReader())
                    {
                        Reader.Read();
                    }
                }
            }
        }

        [WebMethod]
        public void customer_search_history(String userid, String search, DateTime time)
        {

            string MyConString = "SERVER=localhost;" +
                  "DATABASE=web_service;" +
                  "UID=root;" +
                  "PASSWORD=root;";
            using (MySqlConnection connection = new MySqlConnection(MyConString))
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("insert into customer_search_history values(\"{0}\",\"{1}\",\"{2}\")", userid, search, time);
                    using (MySqlDataReader Reader = command.ExecuteReader())
                    {
                        Reader.Read();
                    }
                }
            }
        }


        [WebMethod]
        public string retrieve_cust_firstname(string userid)
        {

            string MyConString = "SERVER=localhost;" +
                  "DATABASE=web_service;" +
                  "UID=root;" +
                  "PASSWORD=root;";


            String temp_username=String.Empty;
            using (MySqlConnection connection = new MySqlConnection(MyConString))
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("select firstname from customer where userid=\"{0}\"",userid);
                    using (MySqlDataReader Reader = command.ExecuteReader())
                    {

                        while (Reader.Read())
                        {

                            for (int i = 0; i < Reader.FieldCount; i++)
                            {
                                temp_username += Reader.GetValue(i).ToString();
                            }
                        }
                        return temp_username;
                    }
                }
            }
            return temp_username;
        }


        [WebMethod]
        public string retrieve_cust_lastname(string userid)
        {

            string MyConString = "SERVER=localhost;" +
                  "DATABASE=web_service;" +
                  "UID=root;" +
                  "PASSWORD=root;";


            string temp_lastname = "";
            using (MySqlConnection connection = new MySqlConnection(MyConString))
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("select lastname from customer where userid=\"{0}\"", userid);
                    using (MySqlDataReader Reader = command.ExecuteReader())
                    {

                        while (Reader.Read())
                        {

                            for (int i = 0; i < Reader.FieldCount; i++)
                            {
                                temp_lastname = Reader.GetValue(i).ToString();
                            }
                        }
                    }
                }
            }
            return temp_lastname;
        }


        [WebMethod]
        public string retrieve_cust_email(string userid)
        {

            string MyConString = "SERVER=localhost;" +
                  "DATABASE=web_service;" +
                  "UID=root;" +
                  "PASSWORD=root;";


            string temp_email = "";
            using (MySqlConnection connection = new MySqlConnection(MyConString))
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("select Email from customer where userid=\"{0}\"", userid);
                    using (MySqlDataReader Reader = command.ExecuteReader())
                    {

                        while (Reader.Read())
                        {

                            for (int i = 0; i < Reader.FieldCount; i++)
                            {
                                temp_email = Reader.GetValue(i).ToString();
                            }
                        }
                    }
                }
            }
            return temp_email;
        }

        [WebMethod]
        public string retrieve_cust_phone(string userid)
        {

            string MyConString = "SERVER=localhost;" +
                  "DATABASE=web_service;" +
                  "UID=root;" +
                  "PASSWORD=root;";


            string temp_phone = "";
            using (MySqlConnection connection = new MySqlConnection(MyConString))
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("select Phone_Number from customer where userid=\"{0}\"", userid);
                    using (MySqlDataReader Reader = command.ExecuteReader())
                    {

                        while (Reader.Read())
                        {

                            for (int i = 0; i < Reader.FieldCount; i++)
                            {
                                temp_phone = Reader.GetValue(i).ToString();
                            }
                        }
                    }
                }
            }
            return temp_phone;
        }



        [WebMethod]
        public string[] retrieve_cust_search(string userid)
        {

            string MyConString = "SERVER=localhost;" +
                  "DATABASE=web_service;" +
                  "UID=root;" +
                  "PASSWORD=root;";


            string[] temp_search = new string[100];
            int counter = 0;
            using (MySqlConnection connection = new MySqlConnection(MyConString))
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("select search_title,time from customer_search_history where userid=\"{0}\"", userid);
                    using (MySqlDataReader Reader = command.ExecuteReader())
                    {

                        while (Reader.Read())
                        {

                            for (int i = 0; i < Reader.FieldCount; i++)
                            {
                                temp_search[counter] = Reader.GetValue(i).ToString();
                                counter++;
                            }

                        }
                    }
                }
               
            }
            return temp_search;
        }

        [WebMethod]
        public string[] retrieve_cust_bought(string userid)
        {

            string MyConString = "SERVER=localhost;" +
                  "DATABASE=web_service;" +
                  "UID=root;" +
                  "PASSWORD=root;";


            string[] temp_bought = new string[100];
            int counter = 0;
            using (MySqlConnection connection = new MySqlConnection(MyConString))
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("select itemtitle,time from customer_history where user_id=\"{0}\"", userid);
                    using (MySqlDataReader Reader = command.ExecuteReader())
                    {

                        while (Reader.Read())
                        {

                            for (int i = 0; i < Reader.FieldCount; i++)
                            {
                                temp_bought[counter] = Reader.GetValue(i).ToString();
                                counter++;
                            }

                        }
                    }
                }

            }
            return temp_bought;
        }

        [WebMethod]
        public string[] retrieve_cartdetails()
        {

            string MyConString = "SERVER=localhost;" +
                  "DATABASE=web_service;" +
                  "UID=root;" +
                  "PASSWORD=root;";


            string[] temp_search = new string[100];
            int counter = 0;
            using (MySqlConnection connection = new MySqlConnection(MyConString))
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("select itemid from addtocart ");
                    using (MySqlDataReader Reader = command.ExecuteReader())
                    {

                        while (Reader.Read())
                        {

                            for (int i = 0; i < Reader.FieldCount; i++)
                            {
                                temp_search[counter] = Reader.GetValue(i).ToString();
                                counter++;
                            }

                        }
                    }
                }

            }
            return temp_search;
        }

        [WebMethod]
        public string[] retrieve_cartdetails1()
        {

            string MyConString = "SERVER=localhost;" +
                  "DATABASE=web_service;" +
                  "UID=root;" +
                  "PASSWORD=root;";


            string[] temp_search = new string[100];
            int counter = 0;
            using (MySqlConnection connection = new MySqlConnection(MyConString))
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = String.Format("select itemtitle from addtocart ");
                    using (MySqlDataReader Reader = command.ExecuteReader())
                    {

                        while (Reader.Read())
                        {

                            for (int i = 0; i < Reader.FieldCount; i++)
                            {
                                temp_search[counter] = Reader.GetValue(i).ToString();
                                counter++;
                            }

                        }
                    }
                }

            }
            return temp_search;
        }
    }

}