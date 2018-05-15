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

            //Se incluye moment.js
            bundles.Add(new ScriptBundle("~/bundles/momentJS").Include("~/Scripts/moment-with-locales.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/momentESJS").Include("~/Scripts/momentLocales/es.js"));

            // Se incluye JQuery Datatables

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

            // Se incluye JSZIP

            bundles.Add(new ScriptBundle("~/bundles/JSZIP").Include("~/Scripts/jszip.min.js"));

            // Se incluye JQuery Datatables Buttons plug-in

            bundles.Add(new ScriptBundle("~/bundles/jqueryDataTablesButtonsJS").Include("~/Scripts/DataTables/dataTables.buttons.min.js"));

            bundles.Add(new StyleBundle("~/bundles/jqueryDataTablesButtonsCSS").Include("~/Content/DataTables/css/buttons.dataTables.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryDataTablesButtonsHTML5JS").Include("~/Scripts/DataTables/buttons.html5.min.js"));


            // Se incluye JQuery Datatables FixedHeader plug-in

            bundles.Add(new ScriptBundle("~/bundles/jqueryDataTablesFixedHeaderJS").Include("~/Scripts/DataTables/dataTables.fixedHeader.min.js"));

            bundles.Add(new StyleBundle("~/bundles/jqueryDataTablesFixedHeaderCSS").Include("~/Content/DataTables/css/fixedHeader.dataTables.min.css"));

            // Se incluye JQuery Datatables Reorder plug-in

            bundles.Add(new ScriptBundle("~/bundles/jqueryDataTablesReorder").Include("~/Scripts/DataTables/dataTables.colReorder.min.js"));

            bundles.Add(new StyleBundle("~/bundles/jqueryDataTablesCSSReorder").Include("~/Content/DataTables/css/colReorder.bootstrap.min.css"));

            // Se incluye JQuery Datatables ColVis plug-in

            bundles.Add(new ScriptBundle("~/bundles/jqueryDataTablesReorder").Include("~/Scripts/DataTables/buttons.colVis.min.js"));

            // Se incluye SELECT2

            bundles.Add(new ScriptBundle("~/bundles/Select2JS").Include("~/Scripts/select2.full.min.js"));

            bundles.Add(new StyleBundle("~/bundles/Select2CSS").Include("~/Content/select2.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/Select2JSES").Include("~/Scripts/i18n/es.js"));

            //Custom JS
            bundles.Add(new ScriptBundle("~/bundles/CollaboratorsJS").Include("~/Scripts/collaborators.js"));

            bundles.Add(new ScriptBundle("~/bundles/CustomJS").Include("~/Scripts/custom.js"));

            bundles.Add(new ScriptBundle("~/bundles/VolunteersJS").Include("~/Scripts/volunteers.js"));

            bundles.Add(new ScriptBundle("~/bundles/SecurityIssuesJS").Include("~/Scripts/security-issues.js"));

            bundles.Add(new ScriptBundle("~/bundles/SecurityIssuesTypesJS").Include("~/Scripts/security-issues-types.js"));

            //TEMPUS DOMINUS BOOTSTRAP 4 DATEPICKER FOR CONFIGURATION FORM https://tempusdominus.github.io/bootstrap-4/
            bundles.Add(new ScriptBundle("~/bundles/BootstrapDatetimePickerTDJS").Include("~/Scripts/tempusdominus-bootstrap-4.min.js"));

            bundles.Add(new StyleBundle("~/bundles/BootstrapDatetimePickerTDCSS").Include("~/Content/tempusdominus-bootstrap4.min.css"));

            //Popper JS
            bundles.Add(new ScriptBundle("~/bundles/PopperJS").Include(
                     "~/Scripts/umd/popper.min.js"));

            //Tether JS to display bootstrap tooltips. Is a prerequesite of bootstrap and must be included before it.

            bundles.Add(new ScriptBundle("~/bundles/TetherJS").Include("~/Scripts/tether.min.js"));
        }
    }
}
