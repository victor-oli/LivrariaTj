import { Component, OnInit } from "@angular/core";
import { BooksBySubject } from "./books-by-subject";
import { ReportService } from "../report-service";

@Component({
  selector: "books-by-subject",
  templateUrl: "books-by-subject.component.html"
})
export class BooksBySubjectComponent implements OnInit {
  private itens: BooksBySubject[] = [];

  constructor(private service: ReportService) { }

  ngOnInit() {
    this.getReport();
  }

  getReport() {
    this.service.getBooksBySubject()
      .subscribe(
        result => this.itens = result,
        error => console.error(error)
      );
  }
}
