angular
    .module('reportsApp')
    .controller("userController", function (userService, $scope, $state, $stateParams, $http) {

        $scope.users = [];
        var data = "";
        $scope.newFirstName = '';
        $scope.newLastName = '';
        $scope.newPosition = '';
        $scope.newLogin = '';
        $scope.userID = '';
        var userId = "";



        userService.getUser()
            .then(function (response) {
                $scope.users = response.data
                console.log($scope.users)
            },
            function (error) {
                console.log(error)
            })

        // Reset model for new user entry
        $scope.Reset = function () {
            $scope.newFirstName = '';
            $scope.newLastName = '';
            $scope.newPosition = '';
            $scope.newLogin = '';
            $scope.newPassword = '';
        }
        $scope.Reset();

        // Add new user
        $scope.Add = function () {
            // Add to user SQL table
            $scope.users.push($scope.newFirstName, $scope.newLastName, $scope.newPosition, $scope.newLogin, $scope.newPassword)
            // Reset new user input boxes after add
            // $scope.Reset();
            console.log($scope.users)
            
        }
        // Still adding new user to SQL database via $http.post
        $scope.postdata = function (firstname, lastname, login, password, position) {
            var data = {
                firstname: $scope.newFirstName,
                lastname: $scope.newLastName,
                login: $scope.newLogin,
                password: $scope.newPassword,
                position: $scope.newPosition
            }
            console.log(data)
            $http.post('http://localhost:50588/api/users', JSON.stringify(data)).then(function (response) {
                if (response.data)
                    $scope.msg = "Post Data Submitted Successfully!";
                    
            }, function (response) {
                $scope.msg = "Service not Exists";
                $scope.statusval = response.status;
                $scope.statustext = response.statusText;
                $scope.headers = response.headers();
                $scope.refresh();
            });
        }

        $scope.deletedata = function (i) {
            var userID = $scope.users[i].id
            $scope.users.splice(i, 1);

            console.log(userID)


            // $scope.DeleteUser = function (id) {
            //     var userId = $scope.users[id].Id;
            //     $http.delete('/api/users/' + userId)
            //           .success(function (data) {
            //              $scope.error = "error " + data;
            //           });
            // Call the service to delete data
            $http.delete('http://localhost:50588/api/users/' + userID, JSON.stringify(data)).then(function (response) {
                if (response.data)
                    $scope.msg = "Data Deleted Successfully!";
            }, function (response) {
                $scope.msg = "Service not Exists";
                $scope.statusval = response.status;
                $scope.statustext = response.statusText;
                $scope.headers = response.headers();
                $scope.refresh();
            });
        }

    });