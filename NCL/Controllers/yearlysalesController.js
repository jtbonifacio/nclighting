angular
.module('reportsApp')
.controller("yearlysalesController", function (yearlysalesService, $scope, $state, $stateParams) {

    $scope.yearlies = [];
    
            yearlysalesService.getYearly()
                .then(function (response) {
                    $scope.yearlies = response.data
                    console.log($scope.yearlies)
                },
                function (error) {
                    console.log(error)
    
                })



})