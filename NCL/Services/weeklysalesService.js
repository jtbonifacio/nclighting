angular
.module('reportsApp')
.service("weeklysalesService", function ($http, $state) {
    
    this.getWeekly = function () {
        // return $http.get("http://192.168.7.94:53031/api/spinners")
        return $http.get("http://localhost:50588/api/weeklies")
    }

})