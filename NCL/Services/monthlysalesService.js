angular
.module('reportsApp')
.service("monthlysalesService", function ($http, $state) {
    this.getMonthly = function () {
        // return $http.get("http://192.168.7.94:53031/api/spinners")
        return $http.get("http://localhost:50588/api/monthlies")
    }

})