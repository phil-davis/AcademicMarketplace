/// <reference path="../T4TS.d.ts" />

module Core
{
    export class MainApp
    {
        "use strict";
        public ngApp: ng.IModule;

        constructor() {
            this.ngApp = angular.module('mainApp', ['ui.router']);

            this.ngApp.controller('homeController', AcademicMarketplace.Controllers.HomeController);
            this.ngApp.controller('aboutController', AcademicMarketplace.Controllers.AboutController);
            this.ngApp.controller('marketplaceController', AcademicMarketplace.Controllers.MarketplaceController);


            this.ngApp.config([
                '$stateProvider', '$urlRouterProvider',
                ($stateProvider: angular.ui.IStateProvider, $urlRouterProvider: angular.ui.IUrlRouterProvider) => {

                    $urlRouterProvider.otherwise(($injector) => {
                        var $state = $injector.get("$state");
                        $state.go("home");
                    });

                    $stateProvider.state('home',
                    {
                        url: '/home',
                        views: {
                            '': {
                                controller: "homeController",
                                templateUrl: 'Modules/Templates/home.html'
                            }
                        }
                        });

                    $stateProvider.state('about',
                        {
                            url: '/about',
                            views: {
                                '': {
                                    controller: "aboutController",
                                    templateUrl: 'Modules/Templates/about.html'
                                }
                            }
                        });

                    $stateProvider.state('marketplace',
                        {
                            url: '/marketplace',
                            views: {
                                '': {
                                    controller: "marketplaceController",
                                    templateUrl: 'Modules/Templates/marketplace.html'
                                }
                            }
                        });
                }
            ]);

            this.ngApp.run
                (['$rootScope', '$state', 
                    ($rootScope, $state) =>
                    {
                        $rootScope.$on('$stateChangeStart', (event, toState, toParams, fromState, fromParams) =>
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