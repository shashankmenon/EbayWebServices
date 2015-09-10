using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

using System.Collections;

using Microsoft.Uddi;
using Microsoft.Uddi.Binding;
using Microsoft.Uddi.Business;
using Microsoft.Uddi.Service;
using Microsoft.Uddi.ServiceType;
using System.Web.Services;


using Ebay_finding;
using ebay_singleitem;
using Service1;

public partial class Default2 : System.Web.UI.Page
{
    //ebay_publishing.Service1 ep = new ebay_publishing.Service1();
    static Dictionary<String,String> dic = new Dictionary<String,String>();
    static string service_value = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //The statement here will not execute on button click
            get_Services();

        }
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string wsdl = TextBox1.Text;
        string tmodelname = TextBox2.Text;
        string tmodeldesp = TextBox3.Text;
        string busi_name = TextBox4.Text;
        string busi_desp = TextBox5.Text;
        string service_name = TextBox6.Text;
        string service_desp = TextBox7.Text;
        if (wsdl != null && tmodelname != null && tmodeldesp != null && busi_name != null && busi_desp != null && service_name != null
             && service_desp != null)
        {
            /*ep.UseDefaultCredentials = true;
            ep.ebay_publishing();*/
            Publish.Url = "http://WIN-NSA2A8QGUJO/uddipublic/publish.asmx";
            Publish.User = "WIN-NSA2A8QGUJO\\Administrator";
            Publish.Password = "Fragment!";


            

            
            //Create tModel
            SaveTModel stm = new SaveTModel();
          
            stm.TModels.Add();
            stm.TModels[0].Name = tmodelname;
            stm.TModels[0].Descriptions.Add("en", tmodeldesp );
            stm.TModels[0].OverviewDoc.OverviewURL = wsdl;
            stm.TModels[0].CategoryBag.Add
            ("CS779",
            "wsdlSpec",
            "uuid:c1acf26d-9672-4404-9d70-39b756e62ab4");
            string sTModelKey = "";
            //Send to UDDI
            try
            {
                TModelDetail tmd = stm.Send();
                sTModelKey = tmd.TModels[0].TModelKey;
            }
            catch (UddiException ue)
            {
                MessageBox.Show(ue.Message);
                return;
            }
            
                //BusinessEntity et = new BusinessEntity();
            //Create Business
            SaveBusiness sb = new SaveBusiness();
            sb.BusinessEntities.Add();
            sb.BusinessEntities[0].Names.Add(busi_name);
            sb.BusinessEntities[0].Descriptions.Add("en", busi_desp);
            //sb.BusinessEntities[0].CategoryBag.Add("categorization", "CS779","uuid:"+sTModelKey);
            //Create BusinessService
            sb.BusinessEntities[0].BusinessServices.Add();
            sb.BusinessEntities[0].BusinessServices[0].Names.Add(service_name);
            sb.BusinessEntities[0].BusinessServices[0].Descriptions.Add("en", service_desp); 
            //sb.BusinessEntities[0].BusinessServices[0].CategoryBag.Add("categorization","CS779","uuid:"+sTModelKey);

            

            //Create BindingTemplate
            sb.BusinessEntities[0].BusinessServices[0].BindingTemplates.Add();
            sb.BusinessEntities[0].BusinessServices[0].BindingTemplates[0].
            Descriptions.Add("en", "Binding");
            sb.BusinessEntities[0].BusinessServices[0].BindingTemplates[0].
            AccessPoint.Text = "Access Point";
            sb.BusinessEntities[0].BusinessServices[0].BindingTemplates[0].
            AccessPoint.URLType = Microsoft.Uddi.Api.URLType.Http;

            //Create tModelInstanceInfo
            sb.BusinessEntities[0].BusinessServices[0].BindingTemplates[0].
            TModelInstanceDetail.TModelInstanceInfos.Add();
            sb.BusinessEntities[0].BusinessServices[0].BindingTemplates[0].
            TModelInstanceDetail.TModelInstanceInfos[0].Descriptions.
            Add("en", "Insert Description Here");
            //Use tModelKey string from above
            sb.BusinessEntities[0].BusinessServices[0].BindingTemplates[0].
            TModelInstanceDetail.TModelInstanceInfos[0].TModelKey = sTModelKey;
            //Send to UDDI
            try
            {
                BusinessDetail bd = sb.Send();
                
            }
            catch (UddiException ue)
            {
                MessageBox.Show(ue.Message);
                return;
            }
            TextBox1.Text = String.Empty;
            TextBox2.Text = String.Empty;
            TextBox3.Text = String.Empty;
            TextBox4.Text = String.Empty;
            TextBox5.Text = String.Empty;
            TextBox6.Text = String.Empty;
            TextBox7.Text = String.Empty;
            get_Services();
        }
        else
        {
            MessageBox.Show("Make sure fields are not empty");
        }
    }
    public void get_Services()
    {
        int counter = 0;
        DropDownList2.Items.Clear();
        dic.Clear();
        try
        {
            Inquire.Url = "http://WIN-NSA2A8QGUJO/uddipublic/inquire.asmx";
            // Create an object to find a Service.
            Microsoft.Uddi.FindService fs = new Microsoft.Uddi.FindService();
            fs.Names.Add("%");
            // Send the FindService request over the connection.
            Microsoft.Uddi.ServiceList servList = fs.Send();
            for (int j = 0; j < servList.ServiceInfos.Count; j++)
            {

                DropDownList2.Items.Insert(counter, new ListItem(servList.ServiceInfos[j].Name));
                dic.Add(servList.ServiceInfos[j].Name , servList.ServiceInfos[j].ServiceKey);
                counter++;
            }
        }
        catch (Exception gen)
        {
            MessageBox.Show(gen.Message);
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedIndex == 1)
        {
            TextBox1.Text = "WIN-NSA2A8QGUJO/Ebay_finding/Service1.asmx?WSDL";
        }
        if (DropDownList1.SelectedIndex == 2)
        {
            TextBox1.Text = "WIN-NSA2A8QGUJO/ebay_singleitem/Service1.asmx?WSDL";
        }
        if (DropDownList1.SelectedIndex == 3)
        {
            TextBox1.Text = "WIN-NSA2A8QGUJO/webservice1/Service1.asmx?WSDL";
        }

    }
    protected void Button3_Click(object sender, EventArgs e)
    {

        foreach (KeyValuePair<string, string> pair in dic)
        {
            
            if (DropDownList2.SelectedValue.Equals(pair.Key) == true)
            {
                service_value = pair.Value;
            }
        }


            Publish.Url = "http://WIN-NSA2A8QGUJO/uddipublic/publish.asmx";
            Publish.User = "WIN-NSA2A8QGUJO\\Administrator";
            Publish.Password = "Fragment!";
            Microsoft.Uddi.DeleteService d = new Microsoft.Uddi.DeleteService();
            d.ServiceKeys.Add(service_value);
            try
            {
                DispositionReport disRep = d.Send();
            }
            catch (UddiException ue)
            {
                MessageBox.Show(ue.Message);
            }
        
            get_Services();
        }

    
}
