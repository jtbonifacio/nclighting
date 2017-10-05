angular
    .module("spinnerApp")
    .controller("ledController", function (ledService, $scope, $state, $stateParams) {


        ledService.getSpinners()
            .then(function (response) {
                $scope.spinners = response.data
                console.log($scope.spinners)
            },
            function (error) {
                console.log(error)

            })

    })
