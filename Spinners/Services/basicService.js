angular
  .module('spinnerApp')
  .service("basicService", function ($http, $state) {

    this.getSpinners = function () {
      return $http.get("http://192.168.7.94:53031/api/spinners")
    }
    this.deleteSpinner = function (id) {
      $http.delete("http://192.168.7.94:53031/api/spinners" + id);
    }

    this.addSpinner = function (spinner) {
      $http.post("http://192.168.7.94:53031/api/spinners", spinner).then(function () {
        $state.go("spinners");
      })
    }

  })