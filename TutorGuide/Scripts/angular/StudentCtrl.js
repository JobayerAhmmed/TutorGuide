app.controller('studentCtrl', function ($scope, $http) {
    $scope.tutors = [];
        
        $scope.interestedTutor = function(id) {
            $http.get('/Post/InterestedTutor?id='+id)
            .then(function (response) {
                window.location.href = '/Post/Interested';
                $scope.tutors = response.data;
            });
        }


    });