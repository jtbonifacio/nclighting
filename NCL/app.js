var app = angular.module("reportsApp", ["ui.router"])

    app.config(function ($stateProvider, $urlRouterProvider) {

        $urlRouterProvider.otherwise("/home");

        $stateProvider
            .state("home", {
                url: "/home",
                templateUrl: "./Views/home.html",
                controller: "homeController"
            })
            .state("inventory", {
                url: "/inventory",
                templateUrl: "./Views/inventory.html",
                controller: "inventoryController"
            })
            .state("monthlysales", {
                url: "/monthlysales",
                templateUrl: "./Views/monthlysales.html",
                controller: "monthlysalesController"
            })
            .state("newsletter", {
                url: "/newsletter",
                templateUrl: "./Views/newsletter.html",
                controller: "newsletterController"
            })
            .state("quarterlysales", {
                url: "/quarterlysales",
                templateUrl: "./Views/quarterlysales.html",
                controller: "quarterlysalesController"
            })
            .state("salesreports", {
                url: "/salesreports",
                templateUrl: "./Views/salesreports.html",
                controller: "salesreportsController"
            })
            .state("weeklysales", {
                url: "/weeklysales",
                templateUrl: "./Views/weeklysales.html",
                controller: "weeklysalesController"
            })
            .state("yearlysales", {
                url: "/yearlysales",
                templateUrl: "./Views/yearlysales.html",
                controller: "yearlysalesController"
            })
            .state("dailysales", {
                url: "/dailysales",
                templateUrl: "./Views/dailysales.html",
                controller: "dailysalesController"
            })
            .state("quotas", {
                url: "/quotas",
                templateUrl: "./Views/quotas.html",
                controller: "quotasController"
            })
            .state("users", {
                url: "/users",
                templateUrl: "./Views/user.html",
                controller: "userController"
            })
    })



