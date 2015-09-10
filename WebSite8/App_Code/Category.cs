using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using com.ebay.developer;
using System.Net;


using eBay.Service.Call;
using eBay.Service.Core.Sdk;
using eBay.Service.Core.Soap;
using System.Configuration;


/// <summary>
/// Summary description for Category
/// </summary>
public class Category : FindingService
{

    protected override System.Net.WebRequest GetWebRequest(Uri uri)
    {
        try
        {
            HttpWebRequest request = (HttpWebRequest)base.GetWebRequest(uri);
            request.Headers.Add("X-EBAY-SOA-SECURITY-APPNAME", "Rocheste-65c8-40ec-ad70-52ab68dbf557");
            request.Headers.Add("X-EBAY-SOA-OPERATION-NAME", "findItemsByCategory");
            request.Headers.Add("X-EBAY-SOA-SERVICE-NAME", "FindingService");
            request.Headers.Add("X-EBAY-SOA-MESSAGE-PROTOCOL", "SOAP11");
            request.Headers.Add("X-EBAY-SOA-SERVICE-VERSION", "1.0.0");
            request.Headers.Add("X-EBAY-SOA-GLOBAL-ID", "EBAY-US");
            return request;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}