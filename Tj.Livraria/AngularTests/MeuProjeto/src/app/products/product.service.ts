import { Injectable } from '@angular/core'
import { HttpClient } from '@angular/common/http'

import { Product } from './product'
import { Observable } from 'rxjs';

@Injectable()
export class ProductService {
    protected UrlServiceV1: string = "http://localhost:3000";

    constructor(private http: HttpClient) { }

    getProducts() : Observable<Product[]> {
        return this.http
            .get<Product[]>(this.UrlServiceV1 + "/products");
    }
}