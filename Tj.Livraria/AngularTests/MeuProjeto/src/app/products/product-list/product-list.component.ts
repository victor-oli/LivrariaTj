import { Component, OnInit } from '@angular/core';
import { ProductService } from '../product.service';
import { Product } from '../product';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styles: [
  ]
})
export class ProductListComponent implements OnInit {
  constructor(private service: ProductService) { }

  public productList: Product[];

  ngOnInit() {
    this.service.getProducts()
      .subscribe(
        productList => {
          this.productList = productList;

          console.log(productList);
        },
        error => console.log(error)
      );
  }
}