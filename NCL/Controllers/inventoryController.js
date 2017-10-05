angular
    .module('reportsApp')
    .controller("inventoryController", function (inventoryService, $scope, $state, $stateParams) {

        $scope.inventory = [];

        inventoryService.getInventory()
            .then(function (response) {
                $scope.inventory = response.data
                console.log($scope.inventory)
            },
            function (error) {
                console.log(error)

            })

    })