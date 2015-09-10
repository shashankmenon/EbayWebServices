using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Net;
using Ebay_finding.Finding;


/// <summary>
/// Summary description for CustomFinding
/// </summary>
    public class CustomFinding : Ebay_finding.Finding.FindingService
    {

        protected override System.Net.WebRequest GetWebRequest(Uri uri)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)base.GetWebRequest(uri);
                request.Headers.Add("X-EBAY-SOA-SECURITY-APPNAME", "Rocheste-4cbc-41a0-bbd8-01b751a3b855");
                request.Headers.Add("X-EBAY-SOA-OPERATION-NAME", "findItemsByKeywords");
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

