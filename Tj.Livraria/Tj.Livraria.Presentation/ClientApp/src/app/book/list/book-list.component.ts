import { Component, OnInit, Input } from "@angular/core";
import { Book } from "../book";
import { BookService } from "../book.service";

@Component({
  selector: 'book-list',
  templateUrl: 'book-list.component.html'
})

export class BookListComponent implements OnInit {
  private books: Book[] = [];
  @Input() private alerts = [];

  constructor(private bookService: BookService) { }

  ngOnInit(): void {
    this.getAll();
  }

  private getAll() {
    this.bookService
      .getAll()
      .subscribe(
        result => this.books = result,
          error => console.log(error)
      );
  }

  refresh() {
    this.getAll();
  }

  addAlert(alert) {
    this.alerts.push({
      type: alert.type,
      msg: alert.message,
      timeout: 5000
    });
  }

  removeAlert(event: any) {
    this.alerts = event;
  }
}
