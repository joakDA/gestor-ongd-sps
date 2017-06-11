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
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            // Se incluye JQuery Datatables from CDN

            bundles.Add( new ScriptBundle("~/bundles/jqueryDataTables").Include("~/Scripts/DataTables/jquery.dataTables.min.js"));

            bundles.Add( new StyleBundle("~/bundles/jqueryDataTablesCSS").Include("~/Content/DataTables/css/jquery.dataTables.min.css"));

            //Se incluye JQuery UI for datepickers
            bundles.Add(new ScriptBundle("~/bundles/jqueryUI").Include("~/Scripts/jquery-ui-1.12.1.min.js"));

            bundles.Add(new StyleBundle("~/bundles/jqueryUICSS").Include("~/Content/themes/base/jquery-ui.min.css"));
        }
    }
}
