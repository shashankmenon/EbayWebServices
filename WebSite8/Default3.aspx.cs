using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
using System.IO;


using System.Xml;
using System.Collections;
using System.Text.RegularExpressions;

using Microsoft.Uddi;
using Microsoft.Uddi.Binding;
using Microsoft.Uddi.Business;
using Microsoft.Uddi.Service;
using Microsoft.Uddi.ServiceType;

using com.ebay.developer;
using Service1;
using Ebay_finding;

using eBay.Service.Call;
using eBay.Service.Core.Sdk;
using eBay.Service.Core.Soap;
using System.Configuration;

public partial class Default3 : System.Web.UI.Page
    {
    
        Service1.Service1 ls = new Service1.Service1();
        Ebay_finding.Service1 ef = new Ebay_finding.Service1();
    
        static Hashtable add = new Hashtable();
        static string itemID;
        static string itemTitle;
        static string userid;
        static ApiContext apiContext;
        Default5 d5 = new Default5();
        Default7 d7 = new Default7();
        Default8 d8 = new Default8();

        DataTable dt = new DataTable();    
        DataTable dt1 = new DataTable();

        public Default3()
        {
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Label3.Text = userid;
                Button3.Visible = false;
                Button5.Visible = false;
                TextBox1.Enabled = false;
                TextBox2.Enabled = false;
                Button1.Enabled = false;
                Button7.Enabled = false;
                Button6.Enabled = false;
                try
                {
                    Inquire.Url = "http://WIN-NSA2A8QGUJO/uddipublic/inquire.asmx";
                    // Create an object to find a Service.
                    Microsoft.Uddi.FindService fs = new Microsoft.Uddi.FindService();
                    fs.Names.Add("%");
                    // Send the FindService request over the connection.
                    Microsoft.Uddi.ServiceList servList = fs.Send();
                    DropDownList1.Items.Add(" ");
                    for (int j = 0; j < servList.ServiceInfos.Count; j++)
                    {
                        DropDownList1.Items.Add(servList.ServiceInfos[j].Name);

                    }
                }
                catch (Exception gen)
                {
                    MessageBox.Show(gen.Message);
                }
            }
        }
        


        protected void Button1_Click(object sender, EventArgs e)
        {


            dt.Columns.Add("ItemID", typeof(string));
            dt.Columns.Add("ItemTitle", typeof(string));
            dt.Columns.Add("pictureURL", typeof(string));
            dt.Columns.Add("Add to Cart", typeof(System.Web.UI.WebControls.Button));
            GridView1.DataSource = dt;
            GridView1.DataBind();

           String keyword = TextBox1.Text;
           Ebay_finding.SearchResult result = ef.Search_by_keyword(keyword);
            ls.customer_search_history(userid,keyword,DateTime.Now);
           
           
            // Looping through response object for result
            foreach (Ebay_finding.SearchItem item in result.item)
            {                
                dt.Rows.Add(item.itemId, item.title, item.galleryURL);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }

        }
        public void GridView1_RowCommand(object sender,GridViewCommandEventArgs e)
        {

            string currentCommand = e.CommandName;
            int currentRowIndex = Int32.Parse(e.CommandArgument.ToString());
            itemID = GridView1.Rows[currentRowIndex].Cells[0].Text;
            itemTitle = GridView1.Rows[currentRowIndex].Cells[1].Text;
            ls.add_to_cart(itemID, itemTitle);
            add.Add(itemID, itemTitle);
            dt1.Columns.Add("ItemID", typeof(string));
            dt1.Columns.Add("ItemTitle", typeof(string));

            
            foreach (DictionaryEntry entry in add)
            {
                dt1.Rows.Add(entry.Key, entry.Value);
                
            }             
                     
        }
        public void sendusername(string username)
        {
            userid = username;
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            ls.clear_addtocart();
            foreach (DictionaryEntry entry in add)
            {
                ls.add_after_buy(entry.Key,entry.Value, userid, DateTime.Now);

            }
            add.Clear();
        }




   
        protected void Button5_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("Default5.aspx");
        }
        protected void Button6_Click(object sender, EventArgs e)
        {
            d7.load();
            Response.Redirect("Default7.aspx");
        }
        protected void Button7_Click(object sender, EventArgs e)
        {
           Response.Redirect("Default8.aspx?id=" + TextBox2.Text);
        }
        protected void Button8_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue.Equals("ebay_finding") == true)
            {

                TextBox1.Enabled = true;
                TextBox2.Enabled = false;
                Button1.Enabled = true;
                Button7.Enabled = false;               
            }

            if (DropDownList1.SelectedValue.Equals("ebay_shopping") == true)
            {

                TextBox1.Enabled = false;
                TextBox2.Enabled = true;
                Button1.Enabled = false;
                Button7.Enabled = true;
            }
            if (DropDownList1.SelectedValue.Equals("ssr") == true)
            {
                Button6.Enabled = true;
                Button3.Enabled = true;
                Button5.Enabled = true;
            }

        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Button3.Visible = true;
            Button5.Visible = true;
            Button3.Enabled = false;
            Button5.Enabled = false;
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
}
