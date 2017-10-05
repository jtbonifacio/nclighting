angular
    .module('reportsApp')
    .service("userService", function ($http, $state) {
        this.getUser = function () {
            return $http.get("http://localhost:50588/api/users")
        }

    })