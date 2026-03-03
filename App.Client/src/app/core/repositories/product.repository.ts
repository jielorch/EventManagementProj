import { inject, Injectable } from "@angular/core";
import { Product } from "../models/product";
import { Observable } from "rxjs";
import { ApiService } from "../services/api.service";

@Injectable({
  providedIn: 'root'
})
export class ProductRepository{
    private controller = 'product';
    private getAction = 'get';
    private moreAction = 'more';
    
    private apiService = inject(ApiService);


    getProducts():Observable<Product[]>{
      return this.apiService.get(this.controller, this.getAction);
    }

    loadMore():Observable<Product[]>{
      return this.apiService.get(this.controller, this.moreAction);
    }

}