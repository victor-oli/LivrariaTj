import { Component, Input, TemplateRef, Output, EventEmitter } from "@angular/core";
import { BsModalRef, BsModalService } from "ngx-bootstrap/modal";
import { SubjectService } from "../subject.service";

@Component({
  selector: 'delete-subject',
  templateUrl: 'delete-subject.component.html'
})

export class DeleteSubjectComponent {
  @Input() public subjectCod: number;
  @Input() public subjectDescription: string;
  @Output() onCantDeleteEvent = new EventEmitter<any>();
  @Output() onCloseEvent = new EventEmitter<any>();

  private modalRef: BsModalRef;

  constructor(private service: SubjectService, private modalService: BsModalService) { }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, { class: 'modal-ls' });
  }

  confirm() {
    this.service
      .deleteSubject(this.subjectCod)
      .subscribe(
        result => {
          if (!result.success)
            this.onCantDeleteEvent.emit({
              message: result.message,
              type: 'danger'
            });
          else {
            this.onCloseEvent.emit();
            this.onCantDeleteEvent.emit({
              message: this.subjectDescription + ' has been deleted',
              type: 'success'
            });
          }

          this.modalRef.hide();
        },
        error => console.error(error)
      );
  }

  decline(): void {
    this.modalRef.hide();
  }
}
