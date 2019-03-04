using System.Web;
using System.Web.Optimization;

namespace IOC_WEB
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));




            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/respond.js",
                "~/Scripts/jquery.min.js",
               "~/Scripts/bootstrap.min.js",
              "~/Scripts/metisMenu.min.js",
                "~/Scripts/raphael.min.js",
               //  "~/Scripts/morris.min.js",
               //"~/Scripts/morris-data.js",
                "~/Scripts/sb-admin-2.min.js",
                          "~/Scripts/DataTables/jquery.dataTables.js",
                "~/Scripts/DataTables/dataTables.bootstrap.js",
                "~/Scripts/bootbox.js"
            ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                     "~/Content/bootstrap.min.css",
                     "~/Content/metisMenu.min.css",
                     "~/Content/sb-admin-2.min.css",
                   "~/Content/morris.css",
                    "~/Content/font-awesome.min.css",
                    "~/Content/DataTables/css/dataTables.bootstrap.css"
                   ));

            bundles.Add(new ScriptBundle("~/bundles/b1").Include(
            "~/Scripts/jquery*",
              "~/Scripts/respond.js",
             "~/Scripts/bootstrap.js"
             
           ));

            bundles.Add(new ScriptBundle("~/bundles/datepickerjs").Include(
           "~/Scripts/bootstrap-datepicker.js"));

            bundles.Add(new StyleBundle("~/Content/datepickercss").Include(
                       "~/Content/datepicker.css"));


            bundles.Add(new StyleBundle("~/Content/c1").Include(
                       "~/Content/bootstrap.min.css",
                       "~/Content.Site.css"
                       ));

        }
    }
}
  