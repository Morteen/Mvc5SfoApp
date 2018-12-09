using System.Web;
using System.Web.Optimization;

namespace SfoApp
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
            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                "~/Scripts/knockout-{version}.debug.js"));

            //Mine scripts
            bundles.Add(new ScriptBundle("~/bundles/SfoScripts").Include(
                "~/Scripts/SfoScripts/test.js",
                "~/Scripts/SfoScripts/Components/LoginView.js",
                "~/Scripts/SfoScripts/Components/VisElever.js",
                "~/Scripts/SfoScripts/Components/RegistrerOppmote.js",
                "~/Scripts/SfoScripts/Navigation.js",
                "~/Scripts/bootbox.js"
                ));



            /*var knockoutBundle = new ScriptBundle("~/bundles/knockout.js")
                .Include("~/Scripts/knockout-{version}.debug.js"); */

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap-flatly.css",
                      "~/Content/site.css"));
        }
    }
}
