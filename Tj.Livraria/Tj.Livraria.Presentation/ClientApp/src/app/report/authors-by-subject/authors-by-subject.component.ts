import { Component, OnInit } from "@angular/core";
import { AuthorsBySubject } from "./authors-by-subject";
import { ReportService } from "../report-service";

@Component({
  selector: "authors-by-subject",
  templateUrl: "authors-by-subject.component.html"
})
export class AuthorsBySubjectComponent implements OnInit {
  private itens: AuthorsBySubject[] = [];

  constructor(private service: ReportService) { }

  ngOnInit() {
    this.getReport();
  }

  getReport() {
    this.service.getAuthorsBySubject()
      .subscribe(
        result => this.itens = result,
        error => console.log(error)
      );
  }
}
