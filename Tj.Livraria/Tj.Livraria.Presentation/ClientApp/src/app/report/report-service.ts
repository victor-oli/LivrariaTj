import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { BooksBySubject } from "./books-by-subject/books-by-subject";
import { AuthorsBySubject } from "./authors-by-subject/authors-by-subject";
import { SubjectsAndBooksByAuthor } from "./subjects-books-by-author/subjects-books-by-author";

@Injectable()
export class ReportService {
  private serviceUrl: string = "https://localhost:44358";

  constructor(private http: HttpClient) { }

  getBooksBySubject(): Observable<BooksBySubject[]> {
    return this.http
      .get<BooksBySubject[]>(this.serviceUrl + "/api/report/GetBooksBySubject");
  }

  getAuthorsBySubject(): Observable<AuthorsBySubject[]> {
    return this.http
      .get<AuthorsBySubject[]>(this.serviceUrl + "/api/report/GetAuthorsBySubject");
  }

  getSubjectsAndBooksByAuthor(): Observable<SubjectsAndBooksByAuthor[]> {
    return this.http
      .get<SubjectsAndBooksByAuthor[]>(this.serviceUrl + "/api/report/GetSubjectsAndBooksByAuthor");
  }
}
