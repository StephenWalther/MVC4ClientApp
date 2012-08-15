using System.Web;
using System.Web.Optimization;

namespace MyApp.Presentation.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Use CDN by default
            bundles.UseCdn = true;

            // Get jQuery/jQuery UI from CDN
            bundles.Add(new ScriptBundle("~/bundles/jquery", "https://ajax.googleapis.com/ajax/libs/jquery/1.8.0/jquery.min.js").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui", "https://ajax.googleapis.com/ajax/libs/jqueryui/1.8.22/jquery-ui.min.js").Include(
                "~/Scripts/jquery-ui-{version}.js"));


            // Bundle app scripts 
            bundles.Add(new ScriptBundle("~/bundles/myapp").Include(
                "~/Scripts/knockout-{version}.js",
                "~/Scripts/date.js",
                "~/Scripts/uiframework-{version}.js",    
                "~/Views/Home/HomeViewModel-{version}.js",
                "~/Views/Account/AccountViewModel-{version}.js"
                ));

            // Separate bundle for top-of-page scripts
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            // Bundle CSS files
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/site.css"));

            

        }
    }
}