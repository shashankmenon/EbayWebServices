using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Service1;


using com.ebay.developer;
using eBay.Service.Call;
using eBay.Service.Core.Sdk;
using eBay.Service.Core.Soap;





    public partial class Default4 : System.Web.UI.Page
    {
        Service1.Service1 ls = new Service1.Service1();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {

            int flag;
            String firstname = TextBox1.Text;
            String lastname = TextBox2.Text;
            String email = TextBox3.Text;
            String number = TextBox4.Text;
            String username = TextBox5.Text;
            String password = TextBox6.Text;
            String reenter_password = TextBox7.Text;


            //Call to webservice method of LocalWS
            flag = ls.register(username, password, reenter_password, firstname, lastname, email, number);
            if (flag == 3)
            {
                MessageBox.Show("Passwords do not match");
                TextBox6.Text = "";
                TextBox7.Text = "";
            }
            if (flag == 0)
            {
                MessageBox.Show("Username already exists");
                TextBox5.Text = "";
            }

            if (flag == 1 || flag == 2)
            {

                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";
                TextBox4.Text = "";
                TextBox5.Text = "";
                TextBox6.Text = "";
                TextBox7.Text = "";
            }

        }
}
