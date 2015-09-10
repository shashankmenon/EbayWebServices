using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections;
using System.Data;
using System.Windows.Forms;

public partial class Default5 : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        string[] cart;
        string[] cart1;
        DataTable carttable = new DataTable();
        Service1.Service1 ls = new Service1.Service1();
        cart=ls.retrieve_cartdetails();
        cart1 = ls.retrieve_cartdetails1();       
        carttable.Columns.Add("ItemID", typeof(string));
        carttable.Columns.Add("ItemTitle", typeof(string));
        for (int i = 0; i < cart.Length; i++)
        {
            carttable.Rows.Add(cart[i], cart1[i]);
        }
        GridView1.DataSource = carttable;
        GridView1.DataBind();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default3.aspx");
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
}