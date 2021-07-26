import { Component, OnInit } from '@angular/core';
import { AccountService } from './account/account.service';
import { BasketService } from './basket/basket.service';
import { IProduct } from './shared/models/Product';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  title = 'SkiNet';
  products: IProduct[];

  constructor(
    private basketService: BasketService,
    private accountService: AccountService
  ) {}
  
  ngOnInit(): void {
    this.getCurrentBasket();
    this.getCurrentUser();
  }

  getCurrentBasket() {
    const basketId = localStorage.getItem('basket_id');
    if (basketId) {
      this.basketService.getBasket(basketId).subscribe(
        () => {
          console.log('initialized');
        },
        (error) => {
          console.log(error);
        }
      );
    }
  }

  getCurrentUser() {
    const token = localStorage.getItem('token');

    this.accountService.loadCurrentUser(token).subscribe(
        () => {
          console.log('Loaded current user');
        },
        (error) => {
          console.log(error);
        }
      );
    }
  }
