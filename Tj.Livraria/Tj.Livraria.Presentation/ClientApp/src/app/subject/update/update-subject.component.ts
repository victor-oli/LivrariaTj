import { Component, EventEmitter, Input, Output, TemplateRef, OnInit } from "@angular/core";
import { BsModalRef, BsModalService } from "ngx-bootstrap/modal";
import { SubjectService } from "../subject.service";

@Component({
  selector: 'update-subject',
  templateUrl: './update-subject.component.html'
})

export class UpdateSubjectComponent implements OnInit {
  @Input() public subjectCod: number;
  @Input() public subjectDescription: string;

  private modalTitle: string;
  private errorAlert: boolean = false;
  private errorMessage: string;
  private modalRef: BsModalRef;

  @Output() onCloseEvent = new EventEmitter<any>();

  constructor(private service: SubjectService, private modalService: BsModalService) { }

  ngOnInit() {
    this.modalTitle = this.subjectDescription;
  }

  onSubmit() {
    this.service.updateSubject({
      subjectCod: this.subjectCod,
      description: this.subjectDescription
    }).subscribe(
      result => {
        if (!result.success) {
          this.errorAlert = true;
          this.errorMessage = result.message;

          return;
        }

        this.errorAlert = false;
        this.errorMessage = '';
        this.modalRef.hide();
        this.onCloseEvent.emit();
      },
      error => console.log(error)
    );
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }
}
