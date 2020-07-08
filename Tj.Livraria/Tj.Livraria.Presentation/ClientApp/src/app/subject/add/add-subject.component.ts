import { Component, EventEmitter, OnInit, Output, TemplateRef } from "@angular/core";
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { SubjectService } from "../subject.service";

@Component({
  selector: "add-subject",
  templateUrl: "./add-subject.component.html"
})

export class AddSubjectCompenent implements OnInit {
  private description: string;
  private modalRef: BsModalRef;
  public showAlert: boolean = false;
  public alertMessage: string;

  @Output() onCloseEvent = new EventEmitter<any>();

  constructor(private service: SubjectService, private modalService: BsModalService) { }

  ngOnInit(): void { }

  onSubmit() {
    this.service
      .addSubject(this.description)
      .subscribe(
        result => {
          if (!result.success) {
            this.showAlert = true;
            this.alertMessage = result.message;

            return;
          }

          this.showAlert = false;
          this.alertMessage = '';
          this.description = '';
          this.modalRef.hide();
          this.onCloseEvent.emit();
        },
        error => {
          this.showAlert = true;
          this.alertMessage = "Internal server error";

          console.log(error);
        }
      );
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }
}
