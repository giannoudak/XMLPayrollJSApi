'use strict';

salaryapp.controller('salaryShowController', function ($scope, $routeParams, transactionService) {
    $scope.title = "Αποτελέσματα Αναζήτησης";
    $scope.emptyItemMessage = "Παρακαλώ πατήστε στο κουμπί 'Εφαρμογή Βεβαιώσεων Μισθοδοσίας' για να αναζητήσετε κάποιο μητρώο."
    console.log(transactionService.getPreSaveTrsn());

    $scope.item = transactionService.getPreSaveTrsn();
    $scope.month = transactionService.getPreSaveMonth();
    $scope.year = transactionService.getPreSaveYear();
    $scope.afm = transactionService.getPreSaveAfm();

});
