angular
  .module('spinnerApp')
  .service("SpinnerService", function ($http) {

    this.getSpinners = function () {
      return $http.get("http://192.168.7.94:53031/api/spinners")
    }

    // this.deleteSpinner = function(id){
    //   $http.delete ("http://localhost:8080/basic" + id);
    // }

    // this.addSpinner = function(spinner){
    //   $http.post("http://localhost:8080/spinners", spinner).then(function(){
    //     $state.go("spinners");
    //   })
    // }

  })