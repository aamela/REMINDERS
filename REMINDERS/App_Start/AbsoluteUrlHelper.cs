using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
namespace REMINDERS.App_Start
{
    public static class AbsoluteUrlHelper
    {
       
            public static string GetAbsoluteUrl(string action, string controller,object routeValues = null )
            {
                var urlHelper = new System.Web.Mvc.UrlHelper(HttpContext.Current.Request.RequestContext);
                //var values = urlHelper.RequestContext.RouteData.Values;
                //var controller = urlHelper.RequestContext.RouteData.Values["controller"].ToString();

                return GetAbsoluteUrl(action, controller, urlHelper, routeValues);
            }

     


        /// <summary>
        /// Creates an absolute "fully qualified" url from an action and controller.
        /// </summary>
      /*  public static string GetAbsoluteUrl(string action, string controller, object routeValues = null)
        {
            var urlHelper = new System.Web.Mvc.UrlHelper(HttpContext.Current.Request.RequestContext);

            return GetAbsoluteUrl(action, controller, urlHelper, routeValues);
        }*/

        /// <summary>
        /// Creates an absolute "fully qualified" url from an action and controller.
        /// </summary>
        public static string GetAbsoluteUrl(string action, string controller, System.Web.Mvc.UrlHelper urlHelper, object routeValues = null)
        {
            var uri = urlHelper.Action(action, controller, routeValues, "http");

            return uri;
        }
    }
}