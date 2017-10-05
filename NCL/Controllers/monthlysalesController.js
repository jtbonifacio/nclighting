angular
    .module('reportsApp')
    .controller("monthlysalesController", function (monthlysalesService, $scope, $state, $stateParams) {

        $scope.monthlies = [];

        monthlysalesService.getMonthly()
            .then(function (response) {
                $scope.monthlies = response.data
                console.log($scope.monthlies)
            },
            function (error) {
                console.log(error)

            })

    })