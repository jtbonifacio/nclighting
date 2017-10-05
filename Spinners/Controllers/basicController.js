angular
    .module('spinnerApp')
    .controller("basicController", function (basicService, $scope, $state, $stateParams) {


        $scope.spinners = [];
        $scope.basicSpinners = []
        $scope.LEDSpinners = []

        basicService.getSpinners()
            .then(function (response) {
                $scope.spinners = response.data
                console.log($scope.spinners)
            },
            function (error) {
                console.log(error)

            })
        $scope.addSpinnerModel = function () {
            basicService.addSpinner($scope.newSpinner);
            console.log($scope.spinners)
        }

        $scope.deleteSpinner = function (spinner) {
            basicService.deleteSpinner(spinner.id);
            $scope.spinners.splice($scope.spinners.indexOf(spinner), 1);
        }
        $scope.getBasic = function () {
            console.log("hey");
            for (var i = 0; i < $scope.spinners.length; i++) {
                if ($scope.spinners[i].model == "Basic") {
                    $scope.basicSpinners.push($scope.spinners[i])
                }
            }
        }
        $scope.getLED = function () {
            console.log("yo")
            for (var i = 0; i < $scope.spinners.length; i++) {
                if ($scope.spinners[i].model == "LED") {
                    $scope.LEDSpinners.push($scope.spinners[i])
                }
            }
        }

    })



