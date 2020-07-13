import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { Book } from "./book";
import { ResponseBase } from "../response-base";

@Injectable()
export class BookService {
  private serviceUrl: string = "https://localhost:44358";

  constructor(private http: HttpClient) { }

  getAll(): Observable<Book[]> {
    return this.http
      .get<Book[]>(this.serviceUrl + "/api/book/GetAll");
  }

  get(bookCod: number): Observable<Book> {
    return this.http
      .get<Book>(this.serviceUrl + "/api/book/Get?cod=" + bookCod);
  }

  add(book: Book): Observable<ResponseBase> {
    return this.http
      .post<ResponseBase>(this.serviceUrl + "/api/book/add", book);
  }

  update(book: Book): Observable<ResponseBase> {
    return this.http
      .put<ResponseBase>(this.serviceUrl + "/api/book/update", book);
  }

  delete(bookCod: number): Observable<ResponseBase> {
    return this.http
      .delete<ResponseBase>(this.serviceUrl + "/api/book/delete?bookCod=" + bookCod);
  }
}
