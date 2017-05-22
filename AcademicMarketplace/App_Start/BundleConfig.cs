﻿using System.Web;
using System.Web.Optimization;

namespace AcademicMarketplace
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                    "~/Scripts/angular.js",
                    "~/Scripts/angular-ui-router.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/core").Include(
                    "~/Modules/mainApp.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/controllers").Include(
                "~/Modules/Services/userService.js",
                "~/Modules/Services/marketplaceListingService.js",
                "~/Modules/Services/workgroupService.js",
                "~/Modules/Controllers/homeController.js",
                "~/Modules/Controllers/aboutController.js",
                "~/Modules/Controllers/marketplaceController.js",
                "~/Modules/Controllers/workgroupController.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
