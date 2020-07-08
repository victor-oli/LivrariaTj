import { Routes } from "@angular/router";
import { HomeComponent } from "./home/home.component";
import { CounterComponent } from "./counter/counter.component";
import { FetchDataComponent } from "./fetch-data/fetch-data.component";
import { AboutComponent } from "./about/about.component";
import { SubjectListComponent } from "./subject/subject-list/subject-list.component";
import { AddSubjectCompenent } from "./subject/add/add-subject.component";

export const rootRouterConfig: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'counter', component: CounterComponent },
  { path: 'fetch-data', component: FetchDataComponent },
  { path: 'about', component: AboutComponent },
  { path: 'subject-list', component: SubjectListComponent },
  { path: 'add-subject', component: AddSubjectCompenent },
];
