'use strict';

angular.module('crmObj', []).filter('isEmptyObject', function () {
    return function (obj) {
        return angular.equals({}, obj);
    };
});