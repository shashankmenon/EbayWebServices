using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;


using com.ebay.developer;
using Service1;

using eBay.Service.Call;
using eBay.Service.Core.Sdk;
using eBay.Service.Core.Soap;
using System.Configuration;
using eBay.Service.Util;


public partial class Default : System.Web.UI.Page
{
    Service1.Service1  ls = new Service1.Service1();
    Default3 d3 = null;
    Default7 d7 = null;

    protected void Page_Load(object sender, EventArgs e)
    {        
        ls.clear_addtocart();
        d3 = new Default3();
        d7 = new Default7();
    }

    
  protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default4.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default6.aspx");
        
           

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        
        Boolean flag;
        String username = TextBox5.Text;
        String password = TextBox6.Text;
       
        //Call to webservice method of LocalWS
        flag = ls.client_login(username, password);

        d3.sendusername(username);
        d7.sendusername(username);
        if (flag == true)
        {
            Response.Redirect("Default3.aspx");
        }
        else
        {

            MessageBox.Show("Invalid");
            TextBox5.Text = "";
            TextBox6.Text = "";

        }
    }
    protected void TextBox6_TextChanged(object sender, EventArgs e)
    {

    }
}
