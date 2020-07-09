import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { AlertModule } from 'ngx-bootstrap/alert';
import { ModalModule } from 'ngx-bootstrap/modal';
import { AboutComponent } from './about/about.component';
import { AppComponent } from './app.component';
import { rootRouterConfig } from './app.routes';
import { HomeComponent } from './home/home.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { AddSubjectCompenent } from './subject/add/add-subject.component';
import { SubjectListComponent } from './subject/subject-list/subject-list.component';
import { SubjectService } from './subject/subject.service';
import { UpdateSubjectComponent } from './subject/update/update-subject.component';
import { DeleteSubjectComponent } from './subject/delete/delete-subject.component';
import { AlertComponent } from './alert/alert.component';
import { ListAuthorComponent } from './author/list/list-author.component';
import { AuthorService } from './author/author.service';


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
    ListAuthorComponent
  ],
  imports: [
    ModalModule.forRoot(),
    AlertModule.forRoot(),
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(rootRouterConfig, { useHash: false, onSameUrlNavigation: 'reload' })],
  providers: [
    SubjectService,
    AuthorService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
