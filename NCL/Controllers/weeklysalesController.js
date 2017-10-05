angular
    .module('reportsApp')
    .controller("weeklysalesController", function (weeklysalesService, $scope, $state, $stateParams) {

        $scope.weeklies = [];

        weeklysalesService.getWeekly()
            .then(function (response) {
                $scope.weeklies = response.data
                console.log($scope.weeklies)
            },
            function (error) {
                console.log(error)

            })



    })