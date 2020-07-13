import { Author } from "../author/author";
import { Subject } from "../subject/subject";

export class Book {
  public bookCod: number = 0;
  public title: string;
  public publishingCompany: string;
  public edition: number = 0;
  public publicationYear: string;
  public price: number = 0;

  public authors: Author[] = [];
  public subjects: Subject[] = [];
}
