angular
.module('reportsApp')
.controller("quarterlysalesController", function (quarterlysalesService, $scope, $state, $stateParams) {

    $scope.quarterlies = [];
    
            quarterlysalesService.getQuarterly()
                .then(function (response) {
                    $scope.quarterlies = response.data
                    console.log($scope.quarterlies)
                },
                function (error) {
                    console.log(error)
    
                })



})