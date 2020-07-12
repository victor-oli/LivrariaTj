import { Component, Input, TemplateRef, Output, EventEmitter } from "@angular/core";
import { Book } from "../book";
import { BsModalRef, BsModalService } from "ngx-bootstrap/modal";
import { BookService } from "../book.service";

@Component({
  selector: 'delete-book',
  templateUrl: 'delete-book.component.html'
})
export class DeleteBookComponent {
  @Input() private book: Book;
  @Output() private onDeleteEvent = new EventEmitter<any>();
  @Output() private onAlertEvent = new EventEmitter<any>();
  private modalRef: BsModalRef;

  constructor(private service: BookService, private modalService: BsModalService) { }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, { class: 'modal-ls' });
  }

  confirm() {
    this.service
      .delete(this.book.bookCod)
      .subscribe(
        result => {
          if (!result.success) {
            this.onAlertEvent.emit({ type: "danger", message: result.message });
          }
          else {
            this.onDeleteEvent.emit();
            this.onAlertEvent.emit({ type: "success", message: this.book.title + " has been deleted" });
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
