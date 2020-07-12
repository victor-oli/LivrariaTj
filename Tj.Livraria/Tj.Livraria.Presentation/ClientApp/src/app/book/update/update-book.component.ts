import { Component, Input, Output, EventEmitter, TemplateRef } from "@angular/core";
import { BsModalRef, BsModalService } from "ngx-bootstrap/modal";
import { Book } from "../book";
import { BookService } from "../book.service";

@Component({
  selector: 'update-book',
  templateUrl: 'update-book.component.html'
})
export class UpdateBookComponent {
  @Input() public book = new Book();
  @Output() public onUpdateEvent = new EventEmitter<any>();
  @Output() private onAlertEvent = new EventEmitter<any>();

  private modalTitle: string;
  private errorAlert = false;
  private errorMessage: string;
  private modalRef: BsModalRef;

  constructor(private service: BookService, private modalService: BsModalService) { }

  ngOnInit() {
    this.modalTitle = "Editar " + this.book.title;
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  validateBook() {
    if (!this.book.edition)
      this.book.edition = 0;

    if (!this.book.price)
      this.book.price = 0;
  }

  onSubmit() {
    this.validateBook();
    this.service
      .update(this.book)
      .subscribe(
        result => {
          if (!result.success) {
            this.errorAlert = true;
            this.errorMessage = result.message;

            return;
          }

          this.onUpdateEvent.emit();
          this.modalRef.hide();
          this.errorAlert = false;
          this.errorMessage = '';
          this.onAlertEvent.emit({ type: "success", message: this.book.title + " has been updated" });
        },
        error => { console.log(this.book); console.error(error); }
      );
  }
}
