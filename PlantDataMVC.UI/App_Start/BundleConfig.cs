﻿using System.Web.Optimization;

namespace PlantDataMVC.UI
{
    public class BundleConfig
    {
        // Removed most bundles, as packages are downloaded with npm, and bundling is being done via Webpack

        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js",
            //            "~/Scripts/jquery-migrate-3.0.0.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
            //            "~/Scripts/jquery-ui-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js"));

            //bundles.Add(new StyleBundle("~/Content/bootstrapcss").Include(
            //          "~/Content/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/sinorcaish-screen.css",
                      "~/Content/CustomStyles.css",
                      "~/Content/Site.css"));

            //bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
            //          "~/Content/themes/base/jquery-ui.min.css"));
        }
    }
}