import { Component, OnInit } from "@angular/core";
import { SubjectService } from "../subject.service";
import { Subject } from "../subject";

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
        subjectListResult => {
          this.subjectList = subjectListResult;
          console.log(subjectListResult);
        },
        error => console.log(error)
      );
  }

  delete(cod: number) {
    console.log(cod);
  }
}
