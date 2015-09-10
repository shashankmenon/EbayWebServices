using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Ebay_finding.Finding;


namespace Ebay_finding
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
        public SearchResult Search_by_keyword(String keyword)
        {
            CustomFinding service = new CustomFinding();
            service.Url = "http://svcs.ebay.com/services/search/FindingService/v1";

            // Creating request object for FindBestMatchItemDetailsByKeywords API
            FindItemsByKeywordsRequest request = new FindItemsByKeywordsRequest();
            // Setting the required property values
            
            request.keywords = keyword;

            
            // Setting the pagination
            PaginationInput pagination = new PaginationInput();
            pagination.entriesPerPageSpecified = true;
            pagination.entriesPerPage = 25;
            pagination.pageNumberSpecified = true;
            pagination.pageNumber = 1;
            request.paginationInput = pagination;

            // Creating response object

            FindItemsByKeywordsResponse response = service.findItemsByKeywords(request);
            SearchResult result = response.searchResult;

            return result;
            
            
        }
    }
}