using System.Web;
using System.Web.Optimization;

namespace DocuClimb.Web
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            // Site
            bundles.Add(new StyleBundle("~/bundles/site/css").Include(
                        "~/Content/Site.css"
                ));

            // Bootstrap

            bundles.Add(new ScriptBundle("~/bundles/bootstrap/js").Include("~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/bundles/bootstrap/css")
                .Include("~/Content/bootstrap/bootstrap.css")
                //.Include("~/Content/bootstrap/bootword/bootstrap-bootword-theme.css")
                //.Include("~/Content/bootstrap/bootword/bootstrap-bootword-site.css")
                .Include("~/Content/bootstrap-overrides.css"));
                                    
        }
    }
}