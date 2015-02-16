﻿'use strict';

salaryapp.controller('salarySearchController', function ($scope, $http, promiseTracker, $location, transactionService) {

    $scope.SalaryDemandViewModel = {};
    $scope.SalaryDetailsViewModel = null;
    $scope.error = false;
    $scope.errors = {};
    $scope.title = "Αναζητήστε τη μισθοδοσίας σας με βάση τα παρακάτω κριτήρια.";

    // Inititate the promise tracker to track form submissions.
    $scope.progress = promiseTracker();


    $scope.submitForm = function () {

        // Set the 'submitted' flag to true
        $scope.submitted = true;

        if ($scope.payrollform.$invalid) {
            return;
        }

        if ($scope.payrollform.$valid) {

            // define the CORS request 
            var req = {
                method: 'POST',
                url: "/api/salary",
                headers: {
                    'Content-Type': "application/json"
                },
                data: $scope.SalaryDemandViewModel,
            }

            var $promise = $http(req).success(function (data, status, headers, config) {


                $scope.SalaryDetailsViewModel = data;
                console.log(data);

                transactionService.preSaveTrsn(data);
                transactionService.preSaveMonth($scope.SalaryDemandViewModel.month);
                transactionService.preSaveYear($scope.SalaryDemandViewModel.year);
                transactionService.preSaveAfm($scope.SalaryDemandViewModel.afm);
                transactionService.preSaveIsAnaplhrwths($scope.SalaryDemandViewModel.IsAnaplhrwths);


                $location.path('/show');

                console.log(data);

            }).error(function (data, status, headers, config) {

                $scope.error = true;
                $scope.errorMessage = data;
                console.log(status + " " + data);
                $scope.payrollform.$setPristine();
                $scope.SalaryDemandViewModel = {};
                $scope.submitted = false;
                console.log(data);

            });
        }


        // Track the request and show its progress to the user.
        $scope.progress.addPromise($promise);

    };

});