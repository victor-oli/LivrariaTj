import { Component, OnInit } from "@angular/core";
import { Author } from "../author";
import { AuthorService } from "../author.service";

@Component({
  selector: 'list-author',
  templateUrl: 'list-author.component.html'
})

export class ListAuthorComponent implements OnInit {
  private authors: Author[] = [];

  constructor(private service: AuthorService) { }

  ngOnInit(): void {
    this.service
      .getAll()
      .subscribe(
        result => this.authors = result,
        error => console.log(error)
      );
  }
}
