angular
    .module('reportsApp')
    .controller("dailysalesController", function (dailysalesService, $scope, $state, $stateParams) {

        $scope.dailies = [];

        dailysalesService.getDaily()
            .then(function (response) {
                $scope.dailies = response.data
                console.log($scope.dailies)
            },
            function (error) {
                console.log(error)

            })
           
    })