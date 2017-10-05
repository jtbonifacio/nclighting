angular
    .module('spinnerApp')
    .controller("SpinnerController", function (SpinnerService, $scope, $state, $stateParams) {

        $scope.spinners = [];

        SpinnerService.getSpinners()
            .then(function (response) {
                $scope.spinners = response.data
            },
            function (error) {
                console.log(error)

            })

            // $scope.addSpinnerModel = function(){
            //     spinnerService.addSpinner($scope.spinner);
            // }

            // $scope.deleteSpinner = function(spinner){
            //     spinnerService.deleteSpinner(spinner.id);
            //     $scope.spinners.splice($scope.spinners.indexOf(spinner),1);
            // }

    })
