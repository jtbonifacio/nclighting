angular
  .module('spinnerApp')
  .service("ledService", function ($http) {

    this.getSpinners = function () {
      return $http.get("http://192.168.7.94:53031/api/spinners")
    }

  })