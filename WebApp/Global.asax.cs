﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace WebApp
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Código que se ejecuta al iniciar la aplicación
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var jqueryBundle = new ScriptBundle("~/Scripts");
            jqueryBundle.Include(new string[] {
                "~/Scripts/jquery-3.3.1.js",
        "~/Scripts/jquery.signalR-2.4.1.js",
        "~/Scripts/jquery.signalR-2.4.1.min.js"});

            BundleTable.Bundles.Add(jqueryBundle);
        }
    }
}