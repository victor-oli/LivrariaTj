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
}
