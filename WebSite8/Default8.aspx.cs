using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

using ebay_singleitem;
using com.ebay.developer;
using Service1;


using eBay.Service.Call;
using eBay.Service.Core.Sdk;
using eBay.Service.Core.Soap;
using System.Configuration;

public partial class Default8 : System.Web.UI.Page
{
    Default3 d3 = null;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            ebay_singleitem.Service1 esi = new ebay_singleitem.Service1();
            string item_id = Request.QueryString["id"];
            GetSingleItemResponseType response = esi.getsingleitemdetails(item_id);
            if (response == null)
            {
                MessageBox.Show("Invalid Item ID. No such item ID exists");
            }
            else
            {
                // output some of the data
                if (response.Item.CurrentPrice != null)
                {
                    Label3.Text = response.Item.CurrentPrice.Value.ToString() + "$";
                }
                else
                {
                    Label3.Text = "Not Available";
                }
                //Label4.Text= response.Item.Description;
                if (response.Item.EndTime != null)
                {
                    Label7.Text = response.Item.EndTime.ToString();
                }
                else
                {
                    Label7.Text = "Not Available";
                }
                if (response.Item.BidCount != null)
                {
                    Label11.Text = response.Item.BidCount.ToString();
                }
                else
                {
                    Label11.Text = "Not Available";
                }

                if (response.Item.BuyItNowPrice != null)
                {
                    Label9.Text = response.Item.BuyItNowPrice.Value.ToString() + "$";
                }
                else
                {
                    Label9.Text = "Not Available";
                }
                if (response.Item.Location != null)
                {
                    Label12.Text = response.Item.Location;
                }
                else
                {
                    Label12.Text = "Not available";
                }
                if (response.Item.Quantity != null)
                {
                    Label14.Text = response.Item.Quantity.ToString();
                }
                else
                {
                    Label14.Text = "Not available";
                }
                if (response.Item.ShippingCostSummary != null)
                {
                    Label15.Text = response.Item.ShippingCostSummary.ShippingServiceCost.Value.ToString() + "$";
                }
                else
                {
                    Label15.Text = "Not Available";
                }
                if (response.Item.ShippingCostSummary != null)
                {
                    Label13.Text = response.Item.ShippingCostSummary.ShippingType.ToString();
                }
                else
                {
                    Label13.Text = "Not Available";
                }
                Image1.ImageUrl = response.Item.GalleryURL;
                Label22.Text = response.Item.ItemID;
                Label24.Text = response.Item.Title;
                if (response.Item.QuantitySold != null)
                {
                    Label26.Text = response.Item.QuantitySold.ToString();
                }
                else
                {
                    Label26.Text = "Not available";
                }
            }
        }
        catch (Exception ue)
        {
            MessageBox.Show(ue.Message);
        }
    }
}