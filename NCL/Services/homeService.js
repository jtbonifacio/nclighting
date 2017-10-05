angular
.module('reportsApp')
.service("homeService", function ($http, $state) {
    this.getUser = function () {
        // return $http.get("http://192.168.7.94:53031/api/spinners")
        return $http.get("http://localhost:50588/api/users")
    }
    // this.uName = function () {
    //     // return $http.get("http://192.168.7.94:53031/api/spinners")
    //     return $http.get("http://localhost:50588/api/users")
    // }
    // this.pWord = function () {
    //     // return $http.get("http://192.168.7.94:53031/api/spinners")
    //     return $http.get("http://localhost:50588/api/users")
    // }

})