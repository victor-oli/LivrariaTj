import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { APP_BASE_HREF } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { MenuComponent } from './navegation/menu/menu.component';
import { HomeComponent } from './navegation/home/home.component';
import { FooterComponent } from './navegation/footer/footer.component';
import { AboutComponent } from './institutionality/about/about.component';
import { ContactComponent } from './institutionality/contact/contact.component';
import { rootRouterConfig } from './app.routes';
import { DataBindingComponent } from './demos/data-binding/data-binding.component';
import { ProductService } from './products/product.service';
import { ProductListComponent } from './products/product-list/product-list.component';
import { HttpClientModule } from '@angular/common/http';
import { ChildAndParentComponent } from './child-and-parent/child-and-parent.component';
import { HeroChildComponent } from './child-and-parent/hero-child/hero-child.component';
import { HeroParentComponent } from './child-and-parent/hero-parent/hero-parent.component';

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    HomeComponent,
    FooterComponent,
    AboutComponent,
    ContactComponent,
    DataBindingComponent,
    ProductListComponent,
    HeroChildComponent,
    HeroParentComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    [RouterModule.forRoot(rootRouterConfig, { useHash: false })]
  ],
  providers: [
    ProductService,
    { provide: APP_BASE_HREF, useValue: '/' }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
