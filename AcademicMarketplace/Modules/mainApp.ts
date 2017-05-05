module Core {
    export class MainApp {
        "use strict";

        public ngApp: ng.IModule;

        constructor() {

            this.ngApp = angular.module('mainApp', ['ui.router']);

            //this.ngApp.controller("homeController", AcademicMarketplace.Controllers.HomeController);


            this.ngApp.config([
                '$stateProvider', '$urlRouterProvider',
                ($stateProvider: angular.ui.IStateProvider, $urlRouterProvider: angular.ui.IUrlRouterProvider) => {

                    $urlRouterProvider.otherwise(($injector) => {
                        var $state = $injector.get("$state");
                        $state.go("home");
                    });
                    //$urlRouterProvider.otherwise('/home');


                    $stateProvider.state('home',
                    {
                        url: '/home',
                        templateUrl: 'Modules/Templates/home.html'
                        //views: {
                        //    'main-body@': {
                        //        controller: 'homeController',
                        //        templateUrl: 'Modules/Templates/home.html'
                        //    }
                        //}
                        });

                    $stateProvider.state('test',
                        {
                            url: '/test',
                            templateUrl: 'Modules/Templates/test.html'
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