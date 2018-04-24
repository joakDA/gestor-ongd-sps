using System.Web;
using System.Web.Optimization;

namespace GestorONG
{
    public class BundleConfig
    {
        // Para obtener más información sobre Bundles, visite http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // preparado para la producción y podrá utilizar la herramienta de compilación disponible en http://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/site.css"));

            // Font awesome
            bundles.Add(new ScriptBundle("~/bundles/FontAwesomeJS").Include(
                     "~/Scripts/FontAwesome/fontawesome-all.min.js"));

            bundles.Add(new StyleBundle("~/Content/FontAwesomeCSS").Include(
                      "~/Content/FontAwesome/fa-svg-with-js.css"));

            bundles.Add(new StyleBundle("~/Content/FontAwesomeLegacyCSS").Include(
                      "~/Content/font-awesome.min.css"));

            // Se incluye JQuery Datatables from CDN

            bundles.Add( new ScriptBundle("~/bundles/jqueryDataTables").Include("~/Scripts/DataTables/jquery.dataTables.min.js"));

            bundles.Add( new StyleBundle("~/bundles/jqueryDataTablesCSS").Include("~/Content/DataTables/css/jquery.dataTables.min.css"));

            //Se incluye JQuery UI for datepickers
            bundles.Add(new ScriptBundle("~/bundles/jqueryUI").Include("~/Scripts/jquery-ui-1.12.1.min.js"));

            bundles.Add(new StyleBundle("~/bundles/jqueryUICSS").Include("~/Content/themes/base/jquery-ui.min.css"));

            //Se incluye Bootstrap Select
            bundles.Add(new ScriptBundle("~/bundles/boostrapSelectJS").Include("~/Scripts/bootstrap-select.min.js"));

            bundles.Add(new StyleBundle("~/bundles/boostrapSelectCSS").Include("~/Content/bootstrap-select.min.css"));

            // Se incluye DatatablesBootstrap 4

            bundles.Add(new ScriptBundle("~/bundles/jqueryDataTablesBootstrapJS").Include("~/Scripts/DataTables/dataTables.bootstrap4.min.js"));
            bundles.Add(new StyleBundle("~/bundles/jqueryDataTablesBootstrapCSS").Include("~/Content/DataTables/css/dataTables.bootstrap4.min.css"));

            //Custom JS
            bundles.Add(new ScriptBundle("~/bundles/CollaboratorsJS").Include("~/Scripts/collaborators.js"));


            //Popper JS
            bundles.Add(new ScriptBundle("~/bundles/PopperJS").Include(
                     "~/Scripts/umd/popper.min.js"));

            //Tether JS to display bootstrap tooltips. Is a prerequesite of bootstrap and must be included before it.

            bundles.Add(new ScriptBundle("~/bundles/TetherJS").Include("~/Scripts/tether.min.js"));
        }
    }
}
