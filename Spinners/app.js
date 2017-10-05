var app = angular.module("spinnerApp", ["ui.router"])

app.config(function ($stateProvider, $urlRouterProvider) {

  $urlRouterProvider.otherwise("Home");

  $stateProvider
    .state("Home", {
      url: "/",
      templateUrl: "./Views/Home.html",
      controller: "HomeController"
    })
    .state("Spinner", {
      url: "/spinner",
      templateUrl: "./Views/Spinner.html",
      controller: "SpinnerController"
    })
    .state("Store", {
      url: "/store",
      templateUrl: "./Views/Store.html",
      controller: "StoreController"
    })
    .state("Profile", {
      url: "/profile",
      templateUrl: "./Views/Profile.html",
      controller: "ProfileController"
    })
    .state("led", {
      url: "/led",
      templateUrl: "./Views/led.html",
      controller: "basicController"
    })
    .state("basic", {
      url: "/basic",
      templateUrl: "./Views/basic.html",
      controller: "basicController"
    })

})