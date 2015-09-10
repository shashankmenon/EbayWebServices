using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Collections;
using System.Data;
using System.Windows.Forms;
using Service1;

using com.ebay.developer;

public partial class Default7 : System.Web.UI.Page
{
    Service1.Service1 ls = new Service1.Service1();
    static string userid;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        Label3.Text = ls.retrieve_cust_firstname(userid);

        Label8.Text = ls.retrieve_cust_lastname(userid);
        Label10.Text = ls.retrieve_cust_email(userid);
        Label11.Text = ls.retrieve_cust_phone(userid);
    }
    public void load()
    {
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        string[] cart;
        Service1.Service1 ls = new Service1.Service1();
        cart = ls.retrieve_cust_search(userid);
        for (int i = 0; i < cart.Length; i++)
        {
            if (i % 2 == 0)
            {
                TextBox1.Text += "---------------------------------";
            }
            TextBox1.Text += Environment.NewLine;
            TextBox1.Text += cart[i];
            TextBox1.Text += Environment.NewLine;
            
            
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string[] search;
        search = ls.retrieve_cust_bought(userid);
        for (int i = 0; i < search.Length; i++)
        {
            if (i % 2 == 0)
            {
                TextBox2.Text += "---------------------------------";
            }
            TextBox2.Text += Environment.NewLine;
            TextBox2.Text += search[i];
            TextBox2.Text += Environment.NewLine;
            
            
        }
    }

    public void sendusername(string username)
    {
        userid = username;
    }
}