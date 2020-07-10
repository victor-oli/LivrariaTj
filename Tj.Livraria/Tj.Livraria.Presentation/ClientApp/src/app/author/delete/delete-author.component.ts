import { Component, Input, TemplateRef, Output, EventEmitter } from "@angular/core";
import { BsModalRef, BsModalService } from "ngx-bootstrap/modal";
import { AuthorService } from "../author.service";

@Component({
  selector: 'delete-author',
  templateUrl: 'delete-author.component.html'
})
export class DeleteAuthorComponent {
  @Input() private authorCod: number;
  @Input() private authorName: string;
  @Output() private onDeleteEvent = new EventEmitter<any>();
  @Output() private onAlertEvent = new EventEmitter<any>();
  private modalRef: BsModalRef;

  constructor(private service: AuthorService, private modalService: BsModalService) { }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, { class: 'modal-ls' });
  }

  confirm() {
    this.service
      .delete(this.authorCod)
      .subscribe(
        result => {
          if (!result.success) {
            this.onAlertEvent.emit({ type: "danger", message: result.message });
          }
          else {
            this.onDeleteEvent.emit();
            this.onAlertEvent.emit({ type: "success", message: this.authorName + " has been deleted" });
          }

          this.modalRef.hide();
        },
        error => console.error("Internal server error")
      );
  }

  decline(): void {
    this.modalRef.hide();
  }
}
