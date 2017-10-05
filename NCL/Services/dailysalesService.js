angular
.module('reportsApp')
.service("dailysalesService", function ($http, $state) {
    this.getDaily = function () {
        return $http.get("http://localhost:50588/api/dailies")
    }

})