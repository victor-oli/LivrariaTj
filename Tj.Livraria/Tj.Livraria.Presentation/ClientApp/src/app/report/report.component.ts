import { Component } from '@angular/core';

@Component({
  selector: 'report',
  templateUrl: 'report.component.html'
})
export class ReportComponent {
  printDiv() {
    var win = window.open();
    win.document.write("<head><link rel='stylesheet' href='https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css' integrity='sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk' crossorigin='anonymous'></head>");
    win.document.write(document.getElementById('divToPrint').innerHTML);
    win.print();
  }
}
