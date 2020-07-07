import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Subject } from "./subject";

@Injectable()
export class SubjectService {
  private serviceUrl: string = "https://localhost:44358";

  constructor(private http: HttpClient) { }

  getSubjects(): Observable<Subject[]> {
    return this.http.get<Subject[]>(this.serviceUrl + "/api/Subject");
  }
}
