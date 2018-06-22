using System.Web.Optimization;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(mysalecity.App_Start.DatePickerHelperBundleConfig), "RegisterBundles")]

namespace mysalecity.App_Start
{
	public class DatePickerHelperBundleConfig
	{
		public static void RegisterBundles()
		{
            BundleTable.Bundles.Add(new ScriptBundle("~/bundles/datepicker").Include(
            "~/Scripts/bootstrap-datetimepicker.js",
            "~/Scripts/bootstrap-datetimepicker.ru.js"));

            BundleTable.Bundles.Add(new StyleBundle("~/Content/datepicker").Include(
            "~/Content/bootstrap-datetimepicker.css"));
		}
	}
}