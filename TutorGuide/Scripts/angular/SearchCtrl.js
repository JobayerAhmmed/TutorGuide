﻿app.controller('searchCtrl',
    function ($scope, $http) {
        $scope.allPost = [];
        $scope.allTutor = [];

        $http.get('/Post/GetAllPost')
            .then(function(response) {
                $scope.allPost = response.data;
            });

        $http.get('/Student/GetAllTutor')
            .then(function(response) {
                $scope.allTutor = response.data;
            });

        $scope.showDetails = function (id) {

            window.location.href = "/Tutor/Details?id="+id;
            
        }
        $scope.showPost = function (id) {

            window.location.href = "/Post/Details?id=" + id;

        }
    });