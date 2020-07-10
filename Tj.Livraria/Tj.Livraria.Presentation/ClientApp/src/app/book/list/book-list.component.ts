import { Component, OnInit } from "@angular/core";
import { Book } from "../book";
import { BookService } from "../book.service";

@Component({
  selector: 'book-list',
  templateUrl: 'book-list.component.html'
})

export class BookListComponent implements OnInit {
  private books: Book[] = [];

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
}
