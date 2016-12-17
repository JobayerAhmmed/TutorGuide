app.controller('studentCtrl', function ($scope, $http) {
    $scope.tutors = [];
    $scope.myPost = true;

    $scope.interestedTutor = function (id) {
        $http.get('/Post/InterestedTutor?id=' + id)
        .then(function (response) {
            $scope.myPost = false;
            $scope.tutors = response.data;
        });
    }

    $scope.tutorDetails = function (id) {
        window.location.href = '/Tutor/Details?id=' + id;
    }

    $scope.postBack = function () {
        $scope.myPost = true;
    }


});