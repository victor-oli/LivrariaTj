import { Routes } from "@angular/router";
import { AboutComponent } from "./about/about.component";
import { ListAuthorComponent } from "./author/list/list-author.component";
import { BookListComponent } from "./book/list/book-list.component";
import { HomeComponent } from "./home/home.component";
import { ReportComponent } from "./report/report.component";
import { SubjectListComponent } from "./subject/subject-list/subject-list.component";

export const rootRouterConfig: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'about', component: AboutComponent },
  { path: 'subject-list', component: SubjectListComponent },
  { path: 'list-author', component: ListAuthorComponent },
  { path: 'book-list', component: BookListComponent },
  { path: 'report', component: ReportComponent }
];
