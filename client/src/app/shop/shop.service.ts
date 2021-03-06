import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IBrand } from '../shared/models/brand';
import { IPagination } from '../shared/models/Pagination';
import { IProductType } from '../shared/models/productType';
import { map } from 'rxjs/operators';
import { ShopParams } from '../shared/models/shopParams';
import { IProduct } from '../shared/models/Product';

@Injectable({
  providedIn: 'root',
})
export class ShopService {
  constructor(private http: HttpClient) {}

  baseUrl = 'https://localhost:5001/api/';

  getProducts(shopParams: ShopParams) {
    let params = new HttpParams();

    if (shopParams.brandId > 0) {
      params = params.append('brandId', shopParams.brandId.toString());
    }

    if (shopParams.productTypeId > 0) {
      params = params.append('typeId', shopParams.productTypeId.toString());
    }

    params = params.append('sort', shopParams.sortCriteria);

    params = params.append('pageIndex', shopParams.pageIndex.toString());

    params = params.append('pageSize', shopParams.pageSize.toString());

    if (shopParams.searchText && shopParams.searchText !== '') {
      params = params.append('searchText', shopParams.searchText.toString());
    }

    return this.http
      .get<IPagination>(this.baseUrl + 'products', {
        observe: 'response',
        params,
      })
      .pipe(
        map((response) => {
          return response.body;
        })
      );
  }

  getProduct(id: number) {
    return this.http.get<IProduct>(this.baseUrl + 'products/' + id.toString());
  }

  getBrands() {
    return this.http.get<IBrand[]>(this.baseUrl + 'products/brands');
  }

  getProductTypes() {
    return this.http.get<IProductType[]>(this.baseUrl + 'products/types');
  }
}
