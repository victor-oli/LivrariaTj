import { Component, EventEmitter, Input, Output, TemplateRef } from "@angular/core";
import { BsModalRef, BsModalService } from "ngx-bootstrap/modal";
import { AuthorService } from "../../author/author.service";
import { Book } from "../book";
import { BookService } from "../book.service";
import { SubjectService } from "../../subject/subject.service";

@Component({
  selector: 'update-book',
  templateUrl: 'update-book.component.html'
})
export class UpdateBookComponent {
  @Input() public originalBook: Book = new Book();
  @Output() public onUpdateEvent = new EventEmitter<any>();
  @Output() private onAlertEvent = new EventEmitter<any>();

  private book: Book;
  private modalTitle: string;
  private errorAlert = false;
  private errorMessage: string;
  private modalRef: BsModalRef;
  private authorList: any[] = [];
  private subjectList: any[] = [];

  constructor(private service: BookService, private modalService: BsModalService,
    private authorService: AuthorService, private subjectService: SubjectService) { }

  ngOnInit() {
    this.book = Object.assign({}, this.originalBook);
    this.modalTitle = "Editar " + this.book.title;

    this.fillAuthorList();
    this.fillSubjectList();
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

  fillSubjectList() {
    this.subjectService.getSubjects()
      .subscribe(
        result => {
          result.forEach(s => this.subjectList.push({
            cod: s.subjectCod,
            text: s.description,
            isChecked: false
          }));
        },
        error => console.error("Internal server error")
      );
  }

  checkRelatedAuthors() {
    this.service.getWithRelationship(this.book.bookCod, true, true)
      .subscribe(
        result => {
          this.authorList.forEach(i => {
            let author = result.authors.filter(a => a.authorCod == i.cod)[0];

            if (author)
              i.isChecked = true;
          });

          this.subjectList.forEach(i => {
            let subject = result.subjects.filter(s => s.subjectCod == i.cod)[0];

            if (subject)
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

  onChangeCheckedSubject(newCheckedList: any[]) {
    this.book.subjects = [];

    if (!newCheckedList)
      return;

    newCheckedList.forEach(s => this.book.subjects.push({
      subjectCod: s.cod,
      description: s.text
    }));
  }

  onSubmit() {
    this.validateBook();
    this.updateAuthorRelationship();
    this.onChangeCheckedSubject(this.subjectList.filter(s => s.isChecked));
    
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
