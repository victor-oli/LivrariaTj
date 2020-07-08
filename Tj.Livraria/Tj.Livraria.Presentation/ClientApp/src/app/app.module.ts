import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { AlertModule } from 'ngx-bootstrap/alert';
import { ModalModule } from 'ngx-bootstrap/modal';
import { AboutComponent } from './about/about.component';
import { AppComponent } from './app.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { HomeComponent } from './home/home.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { AddSubjectCompenent } from './subject/add/add-subject.component';
import { SubjectListComponent } from './subject/subject-list/subject-list.component';
import { SubjectService } from './subject/subject.service';
import { EditSubjectComponent } from './subject/edit/edit-subject.component';
import { rootRouterConfig } from './app.routes';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    AboutComponent,
    SubjectListComponent,
    AddSubjectCompenent,
    EditSubjectComponent
  ],
  imports: [
    ModalModule.forRoot(),
    AlertModule.forRoot(),
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot(rootRouterConfig, { useHash: false, onSameUrlNavigation: 'reload' })],
  providers: [
    SubjectService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }