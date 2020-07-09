import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { Author } from "./author";
import { ResponseBase } from "../response-base";

@Injectable()
export class AuthorService {
  private serviceUrl: string = "https://localhost:44358";

  constructor(private http: HttpClient) { }

  getAll(): Observable<Author[]> {
    return this.http
      .get<Author[]>(this.serviceUrl + "/api/author");
  }

  add(name: string): Observable<ResponseBase> {
    return this.http
      .post<ResponseBase>(this.serviceUrl + "/api/author", {
        name: name
      });
  }

  update(author: Author): Observable<ResponseBase> {
    return this.http
      .put<ResponseBase>(this.serviceUrl + "/api/author", author);
  }

  delete(cod: number): Observable<ResponseBase> {
    return this.http
      .delete<ResponseBase>(this.serviceUrl + "/api/author?authorCod=" + cod);
  }
}
