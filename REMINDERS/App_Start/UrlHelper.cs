using Antlr.Runtime.Misc;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

/// <summary>
/// Descripción breve de UrlHelper
/// </summary>
namespace REMINDERS
{
    public class UrlHelper : System.Web.Mvc.UrlHelper
    {
        private HttpRequestMessage _request;
        private RouteCollection rc = new RouteCollection();
        public RouteCollection routeCollection = RouteTable.Routes;
        /// <summary>
        /// Initializes a new instance of the <see cref="UrlHelper"/> class.
        /// </summary>
        /// <remarks>The default constructor is intended for use by unit testing only.</remarks>
        public UrlHelper()
        {

        }

    }
    
}
