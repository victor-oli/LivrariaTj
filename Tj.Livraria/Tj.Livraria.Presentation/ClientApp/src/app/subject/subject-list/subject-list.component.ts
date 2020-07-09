import { Component, OnInit } from "@angular/core";
import { Subject } from "../subject";
import { SubjectService } from "../subject.service";

@Component({
  selector: 'subject-list',
  templateUrl: './subject-list.component.html'
})

export class SubjectListComponent implements OnInit {
  constructor(private service: SubjectService) { }

  public subjectList: Subject[];
  public alerts: any[] = [];

  ngOnInit(): void {
    this.service.getSubjects()
      .subscribe(
        subjectListResult => this.subjectList = subjectListResult,
        error => console.log(error)
      );
  }

  onRefresh() {
    this.service.getSubjects()
      .subscribe(
        subjectListResult => this.subjectList = subjectListResult,
        error => console.log(error)
      );
  }

  showAlert(event: any) {
    this.alerts.push({
      type: event.type,
      msg: event.message,
      timeout: 5000
    });
  }

  removeAlert(event: any) {
    this.alerts = event;
  }
}
