angular
.module('reportsApp')
.controller("quotasController", function (quotasService, $scope, $state, $stateParams) {

    $scope.quotas = [];

    quotasService.getQuota()
        .then(function (response) {
            $scope.quotas = response.data
            console.log($scope.quotas)
        },
        function (error) {
            console.log(error)

        })



})