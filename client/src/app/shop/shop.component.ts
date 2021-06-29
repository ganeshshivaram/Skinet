import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { PageChangedEvent } from 'ngx-bootstrap/pagination';
import { IBrand } from '../shared/models/brand';
import { IProduct } from '../shared/models/Product';
import { IProductType } from '../shared/models/productType';
import { ShopParams } from '../shared/models/shopParams';
import { ShopService } from './shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss'],
})
export class ShopComponent implements OnInit {
  constructor(private shopService: ShopService) {}

  @ViewChild('search', { static: true }) searchTerm: ElementRef;
  products: IProduct[];
  brands: IBrand[];
  productTypes: IProductType[];
  shopParams = new ShopParams();
  totalItems: number;

  sortOptions = [
    { name: 'Alphabetically', value: 'name' },
    { name: 'Price: Low to High', value: 'priceAsc' },
    { name: 'Price: High to Low', value: 'priceDesc' },
  ];

  ngOnInit(): void {
    this.getProducts();
    this.getBrands();
    this.getProductTypes();
  }

  getProducts() {
    this.shopService.getProducts(this.shopParams).subscribe(
      (response) => {
        this.products = response.data;
        this.shopParams.pageIndex = response.pageIndex;
        this.shopParams.pageSize = response.pageSize;
        this.totalItems = response.count;
      },
      (error) => {
        console.log(error);
      }
    );
  }

  getBrands() {
    this.shopService.getBrands().subscribe(
      (response) => {
        this.brands = [{ id: 0, name: 'All' }, ...response];
      },
      (error) => {
        console.log(error);
      }
    );
  }

  getProductTypes() {
    this.shopService.getProductTypes().subscribe(
      (response) => {
        this.productTypes = [{ id: 0, name: 'All' }, ...response];
      },
      (error) => {
        console.log(error);
      }
    );
  }

  onBrandSelected(brandId: number) {
    this.shopParams.brandId = brandId;
    this.shopParams.pageIndex = 1;
    this.getProducts();
  }

  onProductTypeSelected(productTypeId: number) {
    this.shopParams.productTypeId = productTypeId;
    this.shopParams.pageIndex = 1;
    this.getProducts();
  }

  onSortSelected(sortBy: string) {
    this.shopParams.sortCriteria = sortBy;
    this.getProducts();
  }

  onPageChanged(page: number) {
    if (this.shopParams.pageIndex != page) {
      this.shopParams.pageIndex = page;
      this.getProducts();
    }
  }

  onSearch() {
    this.shopParams.searchText = this.searchTerm.nativeElement.value;
    this.shopParams.pageIndex = 1;
    this.getProducts();
  }

  onReset() {
    this.searchTerm.nativeElement.value = '';
    this.shopParams = new ShopParams();
    this.getProducts();
  }
}
