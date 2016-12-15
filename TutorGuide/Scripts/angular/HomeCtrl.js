app.controller('homeCtrl',
    function ($scope, $http) {
        $scope.faqs = [];

        $http.get('/Home/GetFaq')
            .then(function(response) {
                $scope.faqs = response.data;
            });
    });