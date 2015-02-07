'use strict';

function PrintContent(id) {
    var DocumentContainer = document.getElementById(id);
    var WindowObject = window.open('', 'PrintWindow', 'width=1150,height=auto,top=50,left=50,toolbars=no,scrollbars=yes,status=no,resizable=yes');
    WindowObject.document.write('<HTML>\n<HEAD>\n');
    WindowObject.document.write('<TITLE></TITLE>\n');
    //WindowObject.document.write("<link href='Content/bootstrap.min.css' rel='stylesheet' media='all' />\n");
    WindowObject.document.write("<link href='Content/print.css' rel='stylesheet' media='all' />\n");

   

    WindowObject.document.write('</HEAD>\n');
    WindowObject.document.write('<BODY>\n');
    WindowObject.document.writeln(DocumentContainer.innerHTML);
    WindowObject.document.write('</BODY>\n');
    WindowObject.document.write('</HTML>\n');
    WindowObject.document.close();
    WindowObject.focus();
    //WindowObject.print();
    //WindowObject.close();
}