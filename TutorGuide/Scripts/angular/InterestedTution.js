app.controller('InterestedTution', function ($scope, $http) {

    $scope.tutions = [];

    $http.get('/Tutor/MyTution')
        .then(function (response) {
            $scope.tutions = response.data;
        });


});