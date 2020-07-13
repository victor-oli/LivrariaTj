import { registerLocaleData } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import localePt from '@angular/common/locales/pt';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { CurrencyMaskModule } from "ng2-currency-mask";
import { AlertModule } from 'ngx-bootstrap/alert';
import { ModalModule } from 'ngx-bootstrap/modal';
import { AboutComponent } from './about/about.component';
import { AlertComponent } from './alert/alert.component';
import { AppComponent } from './app.component';
import { rootRouterConfig } from './app.routes';
import { AddAuthorComponent } from './author/add/add-author.component';
import { AuthorService } from './author/author.service';
import { DeleteAuthorComponent } from './author/delete/delete-author.component';
import { ListAuthorComponent } from './author/list/list-author.component';
import { UpdateAuthorComponent } from './author/update/update-author.component';
import { AddBookComponent } from './book/add/add-book.component';
import { BookService } from './book/book.service';
import { DeleteBookComponent } from './book/delete/delete-book.component';
import { BookListComponent } from './book/list/book-list.component';
import { UpdateBookComponent } from './book/update/update-book.component';
import { HomeComponent } from './home/home.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { AddSubjectCompenent } from './subject/add/add-subject.component';
import { DeleteSubjectComponent } from './subject/delete/delete-subject.component';
import { SubjectListComponent } from './subject/subject-list/subject-list.component';
import { SubjectService } from './subject/subject.service';
import { UpdateSubjectComponent } from './subject/update/update-subject.component';
import { SimpleCheckboxListComponent } from './simple-checkbox-list/simple-checkbox-list.component';
import { ReportService } from './report/report-service';
import { BooksBySubjectComponent } from './report/books-by-subject/books-by-subject.component';
import { AuthorsBySubjectComponent } from './report/authors-by-subject/authors-by-subject.component';
registerLocaleData(localePt);

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    AboutComponent,
    SubjectListComponent,
    AddSubjectCompenent,
    UpdateSubjectComponent,
    DeleteSubjectComponent,
    AlertComponent,
    ListAuthorComponent,
    AddAuthorComponent,
    UpdateAuthorComponent,
    DeleteAuthorComponent,
    BookListComponent,
    AddBookComponent,
    UpdateBookComponent,
    DeleteBookComponent,
    SimpleCheckboxListComponent,
    BooksBySubjectComponent,
    AuthorsBySubjectComponent
  ],
  imports: [
    ModalModule.forRoot(),
    AlertModule.forRoot(),
    CurrencyMaskModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(rootRouterConfig, { useHash: false, onSameUrlNavigation: 'reload' })],
  providers: [
    SubjectService,
    AuthorService,
    BookService,
    ReportService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
