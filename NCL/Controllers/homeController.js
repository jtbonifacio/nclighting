angular
    .module('reportsApp')
    .controller("homeController", function (homeService, $scope, $state, $stateParams) {

        // $scope.userName = "";
        // $scope.pass = "";
        $scope.users = [];
        // $scope.uName = [];
        // $scope.pWord = [];

        homeService.getUser()
            .then(function (response) {
                $scope.users = response.data
                console.log($scope.users)
                console.log($scope.userName)
                console.log($scope.pass)
                $scope.login = function () {
                    for (var i = 0; i < $scope.users.length; i++) {
                    if ($scope.userName == $scope.users[i].login && $scope.pass == $scope.users[i].password) {
                        $state.go("newsletter")
                    }
                
                    else {
                        
                    }
                }
            },
            function (error) {
                console.log(error)
            }

            })

        // } else if ($scope.users.length - 1 == [i] && $scope.userName != $scope.users[i].login && $scope.pass != $scope.users[i].password) {
        //     alert("Username or Password is incorrect! Please try again!")
        // } else if ($scope.userName != $scope.users[i].login && $scope.pass != $scope.users[i].password) {

        // }
        // }

    })

