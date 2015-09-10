using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

public partial class Default6 : System.Web.UI.Page
{

    Service1.Service1 ls = new Service1.Service1();
    protected void Page_Load(object sender, EventArgs e)
    {


    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Boolean flag;
        String username = TextBox3.Text;
        String password = TextBox4.Text;

        flag = ls.admin_login(username, password);
        if (flag == true)
        {
            Response.Redirect("Default2.aspx");
        }
        else
        {

            MessageBox.Show("Invalid");
            TextBox3.Text = "";
            TextBox4.Text = "";

        }     
    
    }
}