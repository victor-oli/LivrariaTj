import { Component, Output, EventEmitter, TemplateRef, OnInit } from "@angular/core";
import { Book } from "../book";
import { BookService } from "../book.service";
import { BsModalRef, BsModalService } from "ngx-bootstrap/modal";

@Component({
  selector: 'add-book',
  templateUrl: 'add-book.component.html'
})
export class AddBookComponent implements OnInit {
  private book = new Book();
  private showAlert: boolean = false;
  private alertMessage: string;
  private modalRef: BsModalRef;

  @Output() public onAddEvent = new EventEmitter<any>();
  @Output() private onAlertEvent = new EventEmitter<any>();

  constructor(private service: BookService, private modalService: BsModalService) { }

  ngOnInit(): void { }

  validateBook() {
    if (!this.book.edition)
      this.book.edition = 0;

    if (!this.book.price)
      this.book.price = 0;
  }

  onSubmit() {
    this.validateBook();
    this.service
      .add(this.book)
      .subscribe(
        result => {
          if (!result.success) {
            this.showAlert = true;
            this.alertMessage = result.message;

            return;
          }

          this.onAddEvent.emit();
          this.modalRef.hide();
          this.alertMessage = '';
          this.showAlert = false;
          this.onAlertEvent.emit({ type: "success", message: this.book.title + " has been created" });
        },
        error => console.log(error)
      );
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }
}
