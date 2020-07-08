import { Routes } from '@angular/router';
import { AboutComponent } from './institutionality/about/about.component';
import { ContactComponent } from './institutionality/contact/contact.component';
import { HomeComponent } from './navegation/home/home.component';
import { DataBindingComponent } from './demos/data-binding/data-binding.component';
import { ProductListComponent } from './products/product-list/product-list.component';
import { HeroParentComponent } from './child-and-parent/hero-parent/hero-parent.component';

export const rootRouterConfig: Routes = [
    { path: '', redirectTo: '/home', pathMatch: 'full' },
    { path: 'home', component: HomeComponent },
    { path: 'contact', component: ContactComponent },
    { path: 'about', component: AboutComponent },
    { path: 'feature', component: DataBindingComponent },
    { path: 'product', component: ProductListComponent },
    { path: 'app-hero-parent', component: HeroParentComponent }
];