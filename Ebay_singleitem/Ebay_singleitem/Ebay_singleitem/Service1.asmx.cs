using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Ebay_singleitem.Ebay_singleitemfinding;

namespace Ebay_singleitem
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
        public GetSingleItemResponseType getsingleitemdetails(string item_id)
        {
            Shopping svc = new Shopping();
            // set the URL and it's parameters   
            // Note: Since this is a demo appid, it is very critical to replace the appid with yours to ensure the proper servicing of your application.
            svc.Url = "http://open.api.ebay.com/shopping?appid=Rocheste-4cbc-41a0-bbd8-01b751a3b855&version=523&siteid=0&callname=GetSingleItem&responseencoding=SOAP&requestencoding=SOAP";
            // create a new request type
            GetSingleItemRequestType request = new GetSingleItemRequestType();
            // put in your own item number
            request.ItemID = item_id;
            // we will request Details
            // for IncludeSelector reference see
            // http://developer.ebay.com/DevZone/shopping/docs/CallRef/GetSingleItem.html#detailControls
            request.IncludeSelector = "Details";
            // create a new response type
            GetSingleItemResponseType response = new GetSingleItemResponseType();
            try
            {
                // make the call
                response = svc.GetSingleItem(request);
            }
            catch (Exception ex)
            {
                // catch generic exception
                //Console.WriteLine(ex.Message);
                return null;
            }
            return response;
        }
    }
}