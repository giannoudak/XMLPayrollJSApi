'use strict';

function printWithCss(id) {
    //Works with Chome, Firefox, IE, Safari
    //Get the HTML of div
    var title = document.title;
    var divElements = document.getElementById(id).innerHTML;
    var printWindow = window.open('', 'PrintWindow', 'width=1000,height=auto,top=50,left=50,toolbars=no,scrollbars=yes,status=no,resizable=yes');
    //open the window
    printWindow.document.open();
    //write the html to the new window, link to css file
    printWindow.document.write('<html><head><title>' + title + '</title><link rel="stylesheet" type="text/css" href="http://www.dipechan.gr/oikonomika/Content/print.css"></head><body class="container body-content row-centered">');

    printWindow.document.write(divElements);
    printWindow.document.write('</body></html>');
    printWindow.document.close();
    printWindow.focus();
    //The Timeout is ONLY to make Safari work, but it still works with FF, IE & Chrome.
    //setTimeout(function () {
        printWindow.print();
        printWindow.close();
    //}, 100);
}