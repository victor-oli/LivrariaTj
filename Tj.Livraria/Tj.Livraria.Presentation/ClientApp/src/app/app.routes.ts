import { Routes } from "@angular/router";
import { AboutComponent } from "./about/about.component";
import { HomeComponent } from "./home/home.component";
import { AddSubjectCompenent } from "./subject/add/add-subject.component";
import { SubjectListComponent } from "./subject/subject-list/subject-list.component";

export const rootRouterConfig: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'about', component: AboutComponent },
  { path: 'subject-list', component: SubjectListComponent },
];
