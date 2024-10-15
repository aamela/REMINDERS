using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace REMINDERS
{
    public class RouteConfig
    {
    
        public static void RegisterRoutes(RouteCollection routes)
        {
            
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();
            routes.AppendTrailingSlash = false;

            routes.MapRoute(
             name: "default",
             url: "{controller}/{action}",
             defaults: new { controller = "Home", action = "Index" }
            );

            routes.MapRoute(
                name: "AnadirRecordatorio",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "AnadirRecordatorio" }
            );

            routes.MapRoute(
               name: "EnviarArchivos",
               url: "{controller}/{action}",
               defaults: new { controller = "Home", action = "EnviarArchivos" }
           );

            routes.MapRoute(
               name: "CargarRecordatorios",
               url: "{controller}/{action}",
               defaults: new { controller = "Home", action = "CargarRecordatorios" }
           );

            routes.MapRoute(
               name: "CargarTipoDocumentos",
               url: "{controller}/{action}",
               defaults: new { controller = "Home", action = "CargarTipoDocumentos" }
           );

            routes.MapRoute(
                name: "ModificarRecordatorio",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "ModificarRecordatorio" }
            );

            routes.MapRoute(
                name: "EliminarRecordatorio",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "EliminarRecordatorio" }
            );
        }
    }
}
