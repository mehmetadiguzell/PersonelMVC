using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace PersonelMVC.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                "~/Scripts/jquery-3.6.0.min.js",
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/custom.js",
                "~/Scripts/jquery.unobtrusive-ajax.min.js",
                "~/Scripts/DataTables/jquery.dataTables.min.js",
                "~/Scripts/DataTables/dataTables.bootstrap4.min.js"
                ));


            bundles.Add(new ScriptBundle("~/bundles/css").Include(
                "~/Content/bootstrap.min.css",
                "~/Content/DataTables/css/dataTables.bootstrap4.min.css"
                ));
        }
    }
}