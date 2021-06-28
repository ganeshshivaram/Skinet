import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-page-header',
  templateUrl: './page-header.component.html',
  styleUrls: ['./page-header.component.scss'],
})
export class PageHeaderComponent implements OnInit {
  constructor() {}

  @Input() totalItems: number;
  @Input() pageIndex: number;
  @Input() pageSize: number;

  ngOnInit(): void {}
}
