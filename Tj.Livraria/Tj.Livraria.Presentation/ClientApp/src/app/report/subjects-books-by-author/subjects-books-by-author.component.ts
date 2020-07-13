import { Component, OnInit } from "@angular/core";
import { SubjectsAndBooksByAuthor } from "./subjects-books-by-author";
import { ReportService } from "../report-service";

@Component({
  selector: "subjects-books-by-author",
  templateUrl: "subjects-books-by-author.component.html"
})
export class SubjectsAndBooksByAuthorComponent implements OnInit {
  private itens: SubjectsAndBooksByAuthor[] = [];

  constructor(private service: ReportService) { }

  ngOnInit() {
    this.getReport();

    console.log(this.itens);
  }

  getReport() {
    this.service.getSubjectsAndBooksByAuthor()
      .subscribe(
        result => this.itens = result,
        error => console.error(error)
      );
  }
}
