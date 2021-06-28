import { Component } from '@angular/core';
import { IProduct } from './shared/models/Product';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  title = 'SkiNet';
  products: IProduct[];

  constructor() {}
}
