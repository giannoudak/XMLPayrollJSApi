/// <reference path="views/show.html" />
//defining module

var salaryapp = angular.module('salaryapp', ['ajoslin.promise-tracker', 'ngRoute', 'crmObj'])
    .config(['$routeProvider', '$locationProvider',
      function ($routeProvider, $locationProvider) {
          $routeProvider
            .when('/', {
                //templateUrl: 'App/views/search.html',
                //controller: 'salarySearchController'
            })
            .when('/payroll', {
                templateUrl: 'App/views/search.html',
                controller: 'salarySearchController'
            })
            .when('/show', {
                templateUrl: 'App/views/show.html',
                controller: 'salaryShowController'
            })
            .otherwise({

                redirectTo: '/'

            });

          //$locationProvider.html5Mode(true);
      }]);


// create a service to track model updates
salaryapp.factory('transactionService', [function () {
    var service = {};
    var model = {};
    var month = {};
    var year = {};
    var afm = {};

    // set methods
    service.preSaveTrsn = function (employee) {
        model = employee;
    };

    service.preSaveMonth = function (m) {
        month = m;
    };
    service.preSaveYear = function (y) {
        year = y;
    };
    service.preSaveAfm = function (tin) {
        afm = tin;
    };


    // get methods
    service.getPreSaveTrsn = function () {
        return model;
    };
    service.getPreSaveMonth = function () {
        return month;
    };
    service.getPreSaveYear = function () {
        return year;
    };
    service.getPreSaveAfm = function () {
        return afm;
    }
    return service;
}]);

// creating custom onlyDigits directive
salaryapp.directive('numbersOnly', function () {
    return {
        require: 'ngModel',
        link: function (scope, element, attr, ngModelCtrl) {
            function fromUser(text) {
                if (text) {





                    var transformedInput = text.replace(/[^0-9]/g, '');

                    if (transformedInput !== text) {
                        console.log(text);
                        ngModelCtrl.$setValidity('numbersOnly', false);
                        ngModelCtrl.$setViewValue(transformedInput);
                        ngModelCtrl.$render();
                    } else {
                        ngModelCtrl.$setValidity('numbersOnly', true);
                    }
                    return transformedInput;
                }
                return undefined;
            }
            ngModelCtrl.$parsers.push(fromUser);
        }
    }
});
