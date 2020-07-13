import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { BooksBySubject } from "./books-by-subject";

@Injectable()
export class ReportService {
  private serviceUrl: string = "https://localhost:44358";

  constructor(private http: HttpClient) { }

  getBooksBySubject(): Observable<BooksBySubject[]> {
    return this.http
      .get<BooksBySubject[]>(this.serviceUrl + "/api/report/GetBooksBySubject");
  }
}
