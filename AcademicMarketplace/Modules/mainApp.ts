﻿/// <reference path="../T4TS.d.ts" />

module Core
{
    export class MainApp
    {
        "use strict";
        public ngApp: ng.IModule;

        constructor() {
            this.ngApp = angular.module("mainApp", ["ui.router"]);

            this.ngApp.service("userService", AcademicMarketplace.Services.UserService);
            this.ngApp.service("marketplaceListingService", AcademicMarketplace.Services.MarketplaceListingService);
            this.ngApp.service("workgroupService", AcademicMarketplace.Services.WorkgroupService);

            this.ngApp.controller("homeController", AcademicMarketplace.Controllers.HomeController);
            this.ngApp.controller("marketplaceController", AcademicMarketplace.Controllers.MarketplaceController);
            this.ngApp.controller("workgroupController", AcademicMarketplace.Controllers.WorkgroupController);

            

            this.ngApp.config([
                "$stateProvider", "$urlRouterProvider",
                ($stateProvider: angular.ui.IStateProvider, $urlRouterProvider: angular.ui.IUrlRouterProvider) => {

                    $urlRouterProvider.otherwise(($injector) => {
                        var $state = $injector.get("$state");
                        $state.go("home");
                    });

                    $stateProvider.state("home",
                    {
                        url: "/home",
                        views: {
                            "": {
                                controller: "homeController",
                                templateUrl: "Modules/Templates/home.html"
                            }
                        }
                        });

                    $stateProvider.state("marketplace",
                        {
                            url: "/marketplace",
                            views: {
                                "": {
                                    controller: "marketplaceController",
                                    templateUrl: "Modules/Templates/marketplace.html"
                                }
                            }
                        });

                    $stateProvider.state("workgroups",
                        {
                            url: "/workgroups",
                            views: {
                                "": {
                                    controller: "workgroupController",
                                    templateUrl: "Modules/Templates/workgroups.html"
                                }
                            }
                        });
                }
            ]);

            this.ngApp.run
                (["$rootScope", "$state", 
                    ($rootScope, $state) =>
                    {
                        $rootScope.$on("$stateChangeStart", (event, toState, toParams, fromState, fromParams) =>
                        {
                            if (toState.title) {
                                $rootScope.pageTitle = toState.title;
                            }
                        });
                    }
                ]);
        }
    }

    new MainApp();
}