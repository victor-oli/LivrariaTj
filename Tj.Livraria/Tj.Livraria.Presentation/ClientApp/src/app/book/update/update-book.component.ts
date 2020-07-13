import { Component, EventEmitter, Input, Output, TemplateRef } from "@angular/core";
import { BsModalRef, BsModalService } from "ngx-bootstrap/modal";
import { AuthorService } from "../../author/author.service";
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
  private authorList: any[] = [];

  constructor(private service: BookService, private modalService: BsModalService, private authorService: AuthorService) { }

  ngOnInit() {
    this.modalTitle = "Editar " + this.book.title;

    this.fillAuthorList();
  }

  fillAuthorList() {
    this.authorService.getAll()
      .subscribe(
        result => {
          result.forEach(a => this.authorList.push({
            cod: a.authorCod,
            text: a.name,
            isChecked: false
          }));

          this.checkRelatedAuthors();
        },
        error => console.error("Internal server error")
    );
  }

  checkRelatedAuthors() {
    this.service.getWithRelationship(this.book.bookCod, true, false)
      .subscribe(
        result => {
          this.authorList.forEach(i => {
            let author = result.authors.filter(a => a.authorCod == i.cod)[0];

            if (author)
              i.isChecked = true;
          });
        },
        error => console.error("Internal server error")
      );
  }

  updateAuthorRelationship() {
    this.book.authors = [];

    if (!this.authorList)
      return;

    this.authorList.forEach(a => {
      if (a.isChecked)
        this.book.authors.push({
          authorCod: a.cod,
          name: a.text
        });
    });
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

  onChangeCheckedAuthor(newCheckedList: any[]) {
    this.book.authors = [];

    if (!newCheckedList)
      return;

    newCheckedList.forEach(a => this.book.authors.push({
      authorCod: a.cod,
      name: a.text
    }));
  }

  onSubmit() {
    this.validateBook();
    this.updateAuthorRelationship();

    console.log(this.book.authors);
    console.log(this.authorList);

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
